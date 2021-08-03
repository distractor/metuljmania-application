using AutoMapper;
using MetuljmaniaDatabase.DAL;
using MetuljmaniaDatabase.Helpers;
using MetuljmaniaDatabase.Logic;
using MetuljmaniaDatabase.Models.BlModel;
using MetuljmaniaDatabase.Models.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MetuljmaniaDatabase.Bl
{
    public class PilotBl : BaseBl, IPilotBl
    {
        private readonly IBaseDAL _baseDAL;
        private readonly IEventBl _eventBl;

        public PilotBl(IMapper mapper, IPrincipal principal, IBaseDAL baseDAL, IEventBl eventBl) : base(mapper, principal)
        {
            _baseDAL = baseDAL;
            _eventBl = eventBl;
        }

        #region Public methods.

        ///<inheritdoc/>
        public async Task<List<PilotBlModel>> GetPilotsAsync()
        {
            _logger.Info($"Get pilots.");

            var pilotsDbModel = await _baseDAL.GetPilotsAsync();
            var pilotsBlModel = _mapper.Map<List<PilotBlModel>>(pilotsDbModel);

            return pilotsBlModel;
        }

        ///<inheritdoc/>
        public async Task<PilotBlModel> GetPilotAsync(int id)
        {
            _logger.Info($"Get pilot with id {id}.");

            var pilotDbModel = await _baseDAL.GetPilotAsync(id);
            if (pilotDbModel is null)
            {
                throw new Exception($"Pilot with id {id} not found.");
            }

            var pilotModel = _mapper.Map<PilotBlModel>(pilotDbModel);

            return pilotModel;
        }

        ///<inheritdoc/>
        public async Task<PilotBlModel> GetPilotAsync(int id, string password)
        {
            _logger.Info($"Get pilot with id {id}.");

            var pilotDbModel = await _baseDAL.GetPilotAsync(id);
            if (pilotDbModel is null)
            {
                throw new Exception($"Pilot with id {id} not found.");
            }
            if (pilotDbModel.Password != password)
            {
                _logger.Error("Wrong pilot password, returning empty object.");

                return null;
            }

            var pilotModel = _mapper.Map<PilotBlModel>(pilotDbModel);

            return pilotModel;
        }

        ///<inheritdoc/>
        public async Task CreateApplicationFormAsync(int pilotId)
        {
            _logger.Info($"Creating application form for pilot {pilotId}.");

            // Get pilot details.
            var pilotBlModel = await GetPilotAsync(pilotId);

            // Create directory if needed.
            var uploadDir = FileManagerHelper.GetUploadDirectory(Constants.createdDirectory, true);
            var uploadFilePath = Path.Combine(new[] { uploadDir, $"{pilotBlModel.FirstName}_{pilotBlModel.LastName}_ApplicationForm.pdf" });

            // Create document.
            var pdfHelper = new PdfHelper();
            var pdfDocument = pdfHelper.GenerateDocument(pilotBlModel);
            // Save the document.
            _logger.Info($"Saving pdf {uploadFilePath}.");
            pdfDocument.Save(uploadFilePath);

            // Update pilot.
            _logger.Info($"Updating pilot {pilotId}.");
            var uploadedFile = await _baseDAL.PostFilesAsync(new Models.DbModels.File { Path = uploadFilePath, PilotId = pilotBlModel.Id }, pilotBlModel.Id);
            pilotBlModel.UnSignedApplicationFile = _mapper.Map<FileBlModel>(uploadedFile);
            await _baseDAL.PutPilotAsync(_mapper.Map<Pilot>(pilotBlModel));

            // Notify pilot.
            await NotifyPilot(pilotBlModel, uploadFilePath);
        }

        ///<inheritdoc/>
        public async Task PostPilotsAsync(IFormFile fsdbFile, IFormFile csvFile, int eventId)
        {
            _logger.Info($"Adding pilots to event {eventId}.");

            var eventBlModel = await _eventBl.GetEventAsync(eventId);
            var pilots = new List<PilotBlModel>();

            // Read CSV file with pilots.
            using TextFieldParser csvParser = new(csvFile.OpenReadStream());
            csvParser.CommentTokens = new string[] { "#" };
            csvParser.SetDelimiters(new string[] { "," });
            csvParser.HasFieldsEnclosedInQuotes = true;

            // Skip the row with the column names
            csvParser.ReadLine();

            while (!csvParser.EndOfData)
            {
                // Read current line fields, pointer moves to the next line.
                string[] fields = csvParser.ReadFields();
                var fullName = fields[2].Trim();
                if (string.IsNullOrWhiteSpace(fullName))
                {
                    continue;
                }
                var idx = fullName.LastIndexOf(' ');
                var firstName = fullName.Substring(0, idx);
                var lastName = fullName.Substring(idx + 1);
                var phone = fields[9].Trim();
                var email = fields[10].Trim();
                var flyingSinceString = fields[16].Trim();
                _ = int.TryParse(flyingSinceString, out int flyingSince);
                var licence = fields[14].Trim();

                pilots.Add(new PilotBlModel { FirstName = firstName, LastName = lastName, MobilePhone = phone, Email = email, FlyingSince = flyingSince, Licence = licence });
            }

            // Read FSDB file with pilots.
            XmlSerializer serializer = new(typeof(Fs));
            // Open will return a stream.
            var data = fsdbFile.OpenReadStream();
            // Deserialize.
            var fsdbData = (Fs)serializer.Deserialize(data);

            // Populate pilots with data from FSDB.
            foreach (var pilot in fsdbData.FsCompetition.FsParticipants)
            {
                var fullName = pilot.name.Trim();
                if (string.IsNullOrWhiteSpace(fullName))
                {
                    continue;
                }
                int i = fullName.LastIndexOf(' ');
                var firstName = fullName.Substring(0, i);
                var lastName = fullName.Substring(i + 1);
                var idx = pilots.FindIndex(p => p.FirstName == firstName && p.LastName == lastName);

                // Assign missing data.
                pilots[idx].BirthDate = DateTime.Parse(pilot.birthday);
                pilots[idx].Civlid = pilot.CIVLID;
                pilots[idx].Event = eventBlModel;
                pilots[idx].Fai = pilot.fai_licence;
                pilots[idx].Female = pilot.female == 0;
                pilots[idx].Glider = pilot.glider;
                pilots[idx].Nation = pilot.nat_code_3166_a3;
                pilots[idx].SafetyClass = pilot.FsCustomAttributes.FirstOrDefault(atr => atr.name.Contains("class")).value;
                pilots[idx].Sponsors = pilot.sponsor;
                pilots[idx].Team = pilot.FsCustomAttributes.FirstOrDefault(atr => atr.name.Contains("klub")).value;
            }

            // Post to database.
            var pilotsInDB = await _baseDAL.GetPilotsAsync();
            foreach (var pilot in pilots)
            {
                var pilotDbModel = _mapper.Map<Pilot>(pilot);
                if (!pilotsInDB.Any(p => p.FirstName == pilotDbModel.FirstName && p.LastName == pilotDbModel.LastName && p.Email == pilotDbModel.Email))
                {
                    await _baseDAL.PostPilotAsync(pilotDbModel);
                }
            }
        }

        ///<inheritdoc/>
        public async Task PutPilotAsync(int id, PilotBlModel editPilotModel)
        {
            if (id != editPilotModel.Id)
            {
                throw new Exception("Conflict on given pilot id and pilot object.");
            }

            // Get pilotto check if exists.
            await GetPilotAsync(editPilotModel.Id);
            // Map to DB model.
            var updatePilotDbModel = _mapper.Map<Pilot>(editPilotModel);
            // Update pilot.
            await _baseDAL.PutPilotAsync(updatePilotDbModel);
        }

        ///<inheritdoc/>
        public async Task<PilotBlModel> PostPilotAsync(PilotBlModel pilot)
        {
            // Post.
            var pilotDbModel = _mapper.Map<Pilot>(pilot);
            var insertedPilotDbModel = await _baseDAL.PostPilotAsync(pilotDbModel);
            var insertedPilotModel = await GetPilotAsync(insertedPilotDbModel.Id);

            return insertedPilotModel;
        }

        #endregion

        #region Private methods.
        ///<inheritdoc/>
        private async Task NotifyPilot(PilotBlModel pilot, string filepath)
        {
            _logger.Info($"Notifying pilot {pilot.Id}.");

            // Message.
            var subject = "Application form generated";
            var body = $"<h1>Hi, {pilot.FirstName} {pilot.LastName}!</h1><p>You registered for paragliding cross country competition <strong>{pilot.Event.Name}</strong> and a few seconds ago you have requested the official application form. Attached we are sending you the automatically generated application form (PDF).</p><h5>Ps.:</h5><p>It is <strong>NOT</strong> obligatory, but if you wish you can sign the PDF and upload it back to our database <strong><a href=\"http://register.metuljmania.com\" >following this link</a></strong>.</p><p>Thank you!</p>";

            // Send message.
            try
            {
                NotificationHelper client = new();
                client.Send(pilot.Email, subject, body, filepath);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong wile sending email to {pilot.Email}.");
                throw new Exception($"Something went wrong wile sending email to {pilot.Email}. Exception details: ${ex.Message}.");
            }
        }

        #endregion
    }
}

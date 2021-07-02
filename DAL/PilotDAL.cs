using MetuljmaniaDatabase.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.DAL
{
    public partial class BaseDAL
    {
        ///<inheritdoc/>
        public async Task<List<Pilot>> GetPilotsAsync()
        {
            _logger.Info($"Get pilots from database.");

            using var dbMetuljmaniaContext = new MetuljmaniaContext(_options);
            var pilot = await dbMetuljmaniaContext.Pilot.ToListAsync();

            return pilot;
        }

        ///<inheritdoc/>
        public async Task<Pilot> GetPilotAsync(int id)
        {
            _logger.Info($"Get pilot from database with id {id}.");

            using var dbMetuljmaniaContext = new MetuljmaniaContext(_options);
            var pilot = await dbMetuljmaniaContext.Pilot
                // Include
                .Include(p => p.Event)
                .Include(p => p.CheckFile)
                .Include(p => p.LicenceFile)
                .Include(p => p.IppiFile)
                .FirstOrDefaultAsync(p => p.Id == id);

            return pilot;
        }

        ///<inheritdoc/>
        public async Task<Pilot> PostPilotAsync(Pilot pilot)
        {
            _logger.Info($"Insert new pilot {pilot.FirstName} {pilot.LastName} to database.");

            try
            {
                using var dbMetuljmaniaContext = new MetuljmaniaContext(_options);

                // Assign missing values.
                pilot.CreatedDate = DateTime.UtcNow;
                pilot.File = null;

                // Post.
                dbMetuljmaniaContext.Pilot.Add(pilot);
                await dbMetuljmaniaContext.SaveChangesAsync();

                return pilot;
            }
            catch (Exception ex)
            {
                var msg = $"Something went wrong while posting pilot to database. Exception: {ex.InnerException}";
                _logger.Error(msg);
                throw new Exception(msg);
            }
        }

        ///<inheritdoc/>
        public async Task PutPilotAsync(Pilot pilot)
        {
            _logger.Info($"Update pilot with id {pilot.Id} in database.");

            try
            {
                using var dbMetuljmaniaContext = new MetuljmaniaContext(_options);

                // Get model.
                var pilotDbModel = await dbMetuljmaniaContext.Pilot.FindAsync(pilot.Id);
                // Update values.
                pilotDbModel.EventId = pilot.EventId;
                pilotDbModel.Female = pilot.Female;
                pilotDbModel.Licence = pilot.Licence;
                pilotDbModel.Fai = pilot.Fai;
                pilotDbModel.Civlid = pilot.Civlid;
                pilotDbModel.BirthDate = pilot.BirthDate;
                pilotDbModel.MobilePhone = pilot.MobilePhone;
                pilotDbModel.Adress = pilot.Adress;
                pilotDbModel.FlyingSince = pilot.FlyingSince;
                pilotDbModel.Team = pilot.Team;
                pilotDbModel.Nation = pilot.Nation;
                pilotDbModel.Glider = pilot.Glider;
                pilotDbModel.SafetyClass = pilot.SafetyClass;
                pilotDbModel.GliderColor = pilot.GliderColor;
                pilotDbModel.InsuranceCompany = pilot.InsuranceCompany;
                pilotDbModel.PolicyNumber = pilot.PolicyNumber;
                pilotDbModel.IppiFileId = pilot.IppiFileId != 0 ? pilot.IppiFileId : null;
                pilotDbModel.LicenceFileId = pilot.LicenceFileId != 0 ? pilot.LicenceFileId : null;
                pilotDbModel.CheckFileId = pilot.CheckFileId != 0 ? pilot.CheckFileId : null;
                pilotDbModel.Sponsors = pilot.Sponsors;
                pilotDbModel.Email = pilot.Email;
                pilotDbModel.FirstName = pilot.FirstName;
                pilotDbModel.LastName = pilot.LastName;

                pilotDbModel.ModifiedDate = DateTime.UtcNow;

                // Save to database.
                dbMetuljmaniaContext.Entry(pilotDbModel).State = EntityState.Modified;

                await dbMetuljmaniaContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var msg = $"Something went wrong while putting pilot to database. Exception: {ex.InnerException}";
                _logger.Error(msg);
                throw new Exception(msg);
            }
        }
    }
}

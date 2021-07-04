using AutoMapper;
using MetuljmaniaDatabase.DAL;
using MetuljmaniaDatabase.Helpers;
using MetuljmaniaDatabase.Logic;
using MetuljmaniaDatabase.Models.BlModel;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.Bl
{
    public class FileBl : BaseBl, IFileBl
    {
        private readonly IBaseDAL _baseDAL;

        public FileBl(IMapper mapper, IPrincipal principal, IBaseDAL baseDAL) : base(mapper, principal)
        {
            _baseDAL = baseDAL;
        }

        ///<inheritdoc/>
        public async Task<FileBlModel> PostFilesAsync(IFormFile file, int pilotId)
        {
            _logger.Info($"Posting file {file.FileName}.");

            // Post.
            var uploadedFile = new FileBlModel();
            try
            {
                var datePath = FileManagerHelper.GetUploadDirectory(Constants.uploadDirectory, true);
                var uploadDir = Path.Combine(new[] { Constants.uploadDirectory, datePath });

                // Obtain pilot.
                var pilot = await _baseDAL.GetPilotAsync(pilotId);

                // Copy to storage.
                var uploadFilePath = Path.Combine(new[] { uploadDir, $"{pilot.FirstName}_{pilot.LastName}_{file.FileName}" });
                using var stream = new FileStream(uploadFilePath, FileMode.Create);
                await file.CopyToAsync(stream);

                uploadedFile.Id = 0;
                uploadedFile.Path = uploadFilePath;
                uploadedFile.PilotId = pilotId;
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong while uploading files. Exception: {ex.InnerException}");
                throw new Exception("Something went wrong while uploading files.");
            }

            // Add info to database.
            var uploadedFileDbModel = _mapper.Map<Models.DbModels.File>(uploadedFile);
            uploadedFileDbModel = await _baseDAL.PostFilesAsync(uploadedFileDbModel, pilotId);

            // Map to model and return.
            uploadedFile = _mapper.Map<FileBlModel>(uploadedFileDbModel);

            return uploadedFile;
        }
    }
}

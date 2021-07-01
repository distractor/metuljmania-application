using MetuljmaniaDatabase.Models.DbModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.DAL
{
    public partial class BaseDAL
    {
        ///<inheritdoc/>
        public async Task<File> PostFilesAsync(File file, int pilotId)
        {
            _logger.Info($"Insert new file {file.Path} to database.");

            try
            {
                using var dbMetuljmaniaContext = new MetuljmaniaContext(_options);

                // Add missing entities.
                file.UploadedDate = DateTime.UtcNow;
                file.Pilot = dbMetuljmaniaContext.Pilot.FirstOrDefault(u => u.Id == pilotId);

                // Post files to database.
                dbMetuljmaniaContext.File.Add(file);
                await dbMetuljmaniaContext.SaveChangesAsync();

                return file;
            }
            catch (Exception ex)
            {
                var msg = $"Something went wrong while posting file to database. Exception: {ex.InnerException}";
                _logger.Error(msg);
                throw new Exception(msg);
            }
        }
    }
}

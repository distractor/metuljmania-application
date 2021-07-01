using MetuljmaniaDatabase.Models.BlModel;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.BL
{
    public interface IFileBl
    {
        /// <summary>
        /// Upload files.
        /// </summary>
        /// <param name="files">File.</param>
        /// <param name="pilotId">Uploading user id.</param>
        /// <returns></returns>
        Task<FileBlModel> PostFilesAsync(IFormFile file, int pilotId);
    }
}

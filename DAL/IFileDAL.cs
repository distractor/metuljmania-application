using MetuljmaniaDatabase.Models.DbModels;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.DAL
{
    public partial interface IBaseDAL
    {
        /// <summary>
        /// Upload new files.
        /// </summary>
        /// <param name="file">Files.</param>
        /// <param name="pilotId">Uploading pilot id.</param>
        /// <returns></returns>
        Task<File> PostFilesAsync(File file, int pilotId);
    }
}

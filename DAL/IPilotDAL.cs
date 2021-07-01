using MetuljmaniaDatabase.Models.DbModels;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.DAL
{
    public partial interface IBaseDAL
    {
        /// <summary>
        /// Get pilot by id.
        /// </summary>
        /// <param name="id">Pilot id.</param>
        /// <returns></returns>
        Task<Pilot> GetPilotAsync(int id);

        /// <summary>
        /// Edit pilot.
        /// </summary>
        /// <param name="pilot">Pilot model.</param>
        /// <returns></returns>
        Task PutPilotAsync(Pilot pilot);

        /// <summary>
        /// Insert new pilot.
        /// </summary>
        /// <param name="pilot">New pilot object.</param>
        /// <returns></returns>
        Task<Pilot> PostPilotAsync(Pilot pilot);
    }
}

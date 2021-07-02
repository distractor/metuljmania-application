using MetuljmaniaDatabase.Models.BlModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.Bl
{
    public interface IPilotBl
    {
        /// <summary>
        /// Get pilots.
        /// </summary>
        /// <returns></returns>
        Task<List<PilotBlModel>> GetPilotsAsync();

        /// <summary>
        /// Get pilot by id.
        /// </summary>
        /// <param name="id">Pilot id.</param>
        /// <returns></returns>
        Task<PilotBlModel> GetPilotAsync(int id);

        /// <summary>
        /// Insert new pilot.
        /// </summary>
        /// <param name="pilot">New pilot object.</param>
        /// <returns></returns>
        Task<PilotBlModel> PostPilotAsync(PilotBlModel pilot);

        /// <summary>
        /// Edit pilot.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="editPilotModel">Edit pilot object.</param>
        /// <returns></returns>
        Task PutPilotAsync(int id, PilotBlModel editPilotModel);
    }
}

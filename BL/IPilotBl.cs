using MetuljmaniaDatabase.Models.BlModel;
using Microsoft.AspNetCore.Http;
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
        /// Get pilot by id.
        /// </summary>
        /// <param name="id">Pilot id.</param>
        /// <param name="password">Pilot password.</param>
        /// <returns></returns>
        Task<PilotBlModel> GetPilotAsync(int id, string password);

        /// <summary>
        /// Insert new pilot.
        /// </summary>
        /// <param name="pilot">New pilot object.</param>
        /// <returns></returns>
        Task<PilotBlModel> PostPilotAsync(PilotBlModel pilot);

        /// <summary>
        /// Create and send application form for pilot.
        /// </summary>
        /// <param name="pilotId">Pilot id.</param>
        /// <returns></returns>
        Task CreateApplicationFormAsync(int pilotId);

        /// <summary>
        /// Add pilots.
        /// </summary>
        /// <param name="fsdbFile">Fsdb file.</param>
        /// <param name="csvFile">Csv file.</param>
        /// <param name="eventId">Event id.</param>
        /// <returns></returns>
        Task PostPilotsAsync(IFormFile fsdbFile, IFormFile csvFile, int eventId);

        /// <summary>
        /// Edit pilot.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="editPilotModel">Edit pilot object.</param>
        /// <returns></returns>
        Task PutPilotAsync(int id, PilotBlModel editPilotModel);
    }
}

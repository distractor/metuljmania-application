using MetuljmaniaDatabase.Models.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.DAL
{
    public partial interface IBaseDAL
    {
        /// <summary>
        /// Get events.
        /// </summary>
        /// <returns></returns>
        Task<List<Event>> GetEventsAsync();

        /// <summary>
        /// Get event by id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns></returns>
        Task<Event> GetEventAsync(int id);

        /// <summary>
        /// Insert new event.
        /// </summary>
        /// <param name="event">New event object.</param>
        /// <returns></returns>
        Task<Event> PostEventAsync(Event newEvent);
    }
}

using MetuljmaniaDatabase.Models.BlModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.Bl
{
    public interface IEventBl
    {
        /// <summary>
        /// Get events.
        /// </summary>
        /// <returns></returns>
        Task<List<EventBlModel>> GetEventsAsync();

        /// <summary>
        /// Get event by id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns></returns>
        Task<EventBlModel> GetEventAsync(int id);

        /// <summary>
        /// Insert new event.
        /// </summary>
        /// <param name="event">New event object.</param>
        /// <returns></returns>
        Task<EventBlModel> PostEventAsync(EventBlModel newEvent);
    }
}

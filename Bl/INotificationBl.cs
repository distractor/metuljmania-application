using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.Bl
{
    public interface INotificationBL
    {
        /// <summary>
        /// Notify pilot.
        /// </summary>
        /// <param name="pilotId">Pilot id.</param>
        /// <returns></returns>
        Task NotifyPilotAsync(int pilotId);       
        
        /// <summary>
        /// Notify pilots.
        /// </summary>
        /// <param name="pilotIds">Pilot ids.</param>
        /// <returns></returns>
        Task NotifyPilotsAsync(List<int>? pilotIds = null);
    }
}

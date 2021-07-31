using System.Collections.Generic;

namespace MetuljmaniaDatabase.Models.DTO
{
    /// <summary>
    ///  Notification summary DTO.
    /// </summary>
    public class NotificationSummaryDTO
    {
        /// <summary>
        /// Pilots that need notification sending.
        /// </summary>
        public List<int> PilotIds { get; set; }

        /// <summary>
        /// Pilots that were already sent notficiation.
        /// </summary>
        public List<int> PilotIdsSent { get; set; }

        /// <summary>
        /// Successful only if each pilot was sent notification.
        /// </summary>
        public bool Success { get; set; }
    }
}

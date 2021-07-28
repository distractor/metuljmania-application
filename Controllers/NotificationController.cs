using AutoMapper;
using MetuljmaniaDatabase.Bl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetuljmaniaDatabase.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationController : BaseApiController
    {
        private readonly INotificationBL _notificationBL;

        public NotificationController(IMapper mapper, IPrincipal principal, INotificationBL notificationBL) : base(mapper, principal)
        {
            _notificationBL = notificationBL;
        }

        // POST api/<NotificationController>
        /// <summary>
        /// Notify pilot.
        /// </summary>
        /// <param name="pilotId">Pilot id.</param>
        /// <returns></returns>
        [HttpPost("NotifyPilot")]
        [AllowAnonymous]
        public async Task<ActionResult> NotifyPilotAsync(int pilotId)
        {
            // Notify pilot.
            await _notificationBL.NotifyPilotAsync(pilotId);


            return Ok();
        }

        // POST api/<NotificationController>
        /// <summary>
        /// Notify pilots.
        /// </summary>
        /// <param name="pilotIds">List of pilot ids.</param>
        /// <returns></returns>
        [HttpPost("NotifyPilots")]
        [AllowAnonymous]
        public async Task<ActionResult> NotifyPilotsAsync(List<int>? pilotIds = null)
        {
            // Notify pilots.
            await _notificationBL.NotifyPilotsAsync(pilotIds);


            return Ok();
        }
    }
}

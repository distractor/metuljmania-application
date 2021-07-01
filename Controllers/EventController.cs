using AutoMapper;
using MetuljmaniaDatabase.BL;
using MetuljmaniaDatabase.Models.BlModel;
using MetuljmaniaDatabase.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventController : BaseApiController
    {
        private readonly IEventBl _eventBl;

        public EventController(IMapper mapper, IPrincipal principal, IEventBl EventBl) : base(mapper, principal)
        {
            _eventBl = EventBl;
        }

        // GET: api/<EventController>
        /// <summary>
        /// Get events.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEvents")]
        [AllowAnonymous]
        public async Task<List<EventDTO>> GetEventsAsync()
        {
            // Get events.
            var eventBlModels = await _eventBl.GetEventsAsync();
            var eventDTOs = _mapper.Map<List<EventDTO>>(eventBlModels);

            return eventDTOs;
        }

        // GET api/<EventController>/5
        /// <summary>
        /// Get event by id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<EventDTO>> GetEventAsync(int id)
        {
            // Get event.
            var eventBlModel = await _eventBl.GetEventAsync(id);
            var eventDTO = _mapper.Map<EventDTO>(eventBlModel);

            return Ok(eventDTO);
        }

        // POST api/<EventController>
        /// <summary>
        /// Insert new event.
        /// </summary>
        /// <param name="newEventDTO">Event as object.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<NewEventDTO>> PostEventAsync(NewEventDTO newEventDTO)
        {
            // Post new event group.
            var newEventBlModel = _mapper.Map<EventBlModel>(newEventDTO);
            var insertedEventBlModel = await _eventBl.PostEventAsync(newEventBlModel);
            var insertedEventDTO = _mapper.Map<EventDTO>(insertedEventBlModel);

            return CreatedAtAction("GetEvent", new { id = insertedEventDTO.Id }, insertedEventDTO);
        }
    }
}

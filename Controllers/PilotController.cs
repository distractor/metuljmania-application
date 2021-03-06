using AutoMapper;
using MetuljmaniaDatabase.Bl;
using MetuljmaniaDatabase.Helpers;
using MetuljmaniaDatabase.Models.BlModel;
using MetuljmaniaDatabase.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
    public class PilotController : BaseApiController
    {
        private readonly IPilotBl _pilotBl;

        public PilotController(IMapper mapper, IPrincipal principal, IPilotBl pilotBl) : base(mapper, principal)
        {
            _pilotBl = pilotBl;
        }

        // GET: api/<PilotController>
        /// <summary>
        /// Get pilots basicinfo.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPilotsBasicInfo")]
        [AllowAnonymous]
        public async Task<List<BasicInfoDTO>> GetPilotsBasicInfo()
        {
            // Get Pilots.
            var pilotBlModels = await _pilotBl.GetPilotsAsync();
            var pilotsDTOs = _mapper.Map<List<BasicInfoDTO>>(pilotBlModels);

            return pilotsDTOs;
        }

        // GET api/<PilotController>/5
        /// <summary>
        /// Get pilot by id.
        /// </summary>
        /// <param name="id">Pilot id.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<PilotDTO>> GetPilotAsync(int id)
        {
            // Get pilot.
            var pilotBlModel = await _pilotBl.GetPilotAsync(id);
            var pilotDTO = _mapper.Map<PilotDTO>(pilotBlModel);

            return Ok(pilotDTO);
        }

        // GET api/<PilotController>/5
        /// <summary>
        /// Get pilot by id.
        /// </summary>
        /// <param name="id">Pilot id.</param>
        /// <param name="password">Pilot password.</param>
        /// <returns></returns>
        [HttpGet("AuthenticatePilot")]
        [AllowAnonymous]
        public async Task<ActionResult<PilotDTO>> AuthenticatePilot(int id, string password)
        {
            // Get pilot.
            var pilotBlModel = await _pilotBl.GetPilotAsync(id, password);
            if (pilotBlModel == null)
            {
                return NotFound();
            }
            var pilotDTO = _mapper.Map<PilotDTO>(pilotBlModel);

            return Ok(pilotDTO);
        }

        // POST api/<PilotController>
        /// <summary>
        /// Insert new pilot.
        /// </summary>
        /// <param name="newPilotDTO">Pilot as object.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<PilotDTO>> PostPilotAsync(NewPilotDTO newPilotDTO)
        {
            // Post new pilot.
            var newPilotBlModel = _mapper.Map<PilotBlModel>(newPilotDTO);
            var insertedPilotBlModel = await _pilotBl.PostPilotAsync(newPilotBlModel);
            var insertedPilotDTO = _mapper.Map<PilotDTO>(insertedPilotBlModel);

            return CreatedAtAction("GetPilot", new { id = insertedPilotDTO.Id }, insertedPilotDTO);
        }

        // POST api/<PilotController>
        /// <summary>
        /// Create application form for pilot.
        /// </summary>
        /// <param name="pilotId">Pilot id</param>
        /// <returns></returns>
        [HttpPost("CreateApplicationFormAsync")]
        [AllowAnonymous]
        public async Task<ActionResult> CreateApplicationFormAsync(int pilotId)
        {
            // Post new event group.
            await _pilotBl.CreateApplicationFormAsync(pilotId);

            return Ok();
        }

        // POST api/<PilotController>
        /// <summary>
        /// Add pilots.
        /// </summary>
        /// <param name="fsdbFile">Fsdb file.</param>
        /// <param name="csvFile">Csv file.</param>
        /// <param name="eventId">Event id.</param>
        /// <returns></returns>
        [HttpPost("PostPilotsAsync")]
        [AllowAnonymous]
        public async Task<ActionResult> PostPilotsAsync(IFormFile fsdbFile, IFormFile csvFile, int eventId)
        {
            // Post new event group.
            await _pilotBl.PostPilotsAsync(fsdbFile, csvFile, eventId);

            return Ok();
        }

        // PUT: api/Pilot/5
        /// <summary>
        /// Update pilot.
        /// </summary>
        /// <param name="id">Pilot Id</param>
        /// <param name="pilot">Pilot object with updated properties</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [AllowAnonymous]
        public async Task<ActionResult> PutPilotAsync(int id, EditPilotDTO pilot)
        {
            // Edit Pilot.
            var pilotBlModel = _mapper.Map<PilotBlModel>(pilot);
            await _pilotBl.PutPilotAsync(id, pilotBlModel);

            return Ok();
        }
    }
}

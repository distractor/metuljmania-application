using AutoMapper;
using MetuljmaniaDatabase.BL;
using MetuljmaniaDatabase.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetuljmaniaDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : BaseApiController
    {
        private readonly IFileBl _fileBl;

        public FileController(IMapper mapper, IPrincipal principal, IFileBl fileBl) : base(mapper, principal)
        {
            _fileBl = fileBl;
        }

        // POST api/<FileController>
        /// <summary>
        /// Upload files.
        /// </summary>
        /// <param name="file">File.</param>
        /// <param name="pilotId">Uploading pilot id.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<List<FileDTO>>> PostFilesAsync(IFormFile file, int pilotId)
        {
            // Post file.
            var uploadedFiles = await _fileBl.PostFilesAsync(file, pilotId);
            var uploadedFilesDTO = _mapper.Map<FileDTO>(uploadedFiles);

            return Ok(uploadedFilesDTO);
        }
    }
}

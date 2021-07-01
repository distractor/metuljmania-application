using AutoMapper;
using MetuljmaniaDatabase.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Security.Principal;

namespace MetuljmaniaDatabase.Controllers
{
    [LogAPI]
    [Authorize]
    public class BaseApiController : ControllerBase
    {
        /// <summary>
        /// Logger.
        /// </summary>
        protected readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Mapper.
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// Principal.
        /// </summary>
        protected readonly IPrincipal _principal;

        public BaseApiController(IMapper mapper, IPrincipal principal)
        {
            _mapper = mapper;
            _principal = principal;
        }
    }
}
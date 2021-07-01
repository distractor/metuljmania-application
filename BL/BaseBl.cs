using AutoMapper;
using NLog;
using System.Security.Principal;

namespace MetuljmaniaDatabase.BL
{
    public class BaseBl
    {
        protected readonly Logger _logger = LogManager.GetCurrentClassLogger();
        protected readonly IMapper _mapper;
        protected readonly IPrincipal _principal;

        public BaseBl(IMapper mapper, IPrincipal principal)
        {
            _mapper = mapper;
            _principal = principal;
        }
    }
}

using MetuljmaniaDatabase.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog;

namespace MetuljmaniaDatabase.DAL
{
    public partial class BaseDAL : IBaseDAL
    {
        protected readonly DbContextOptions<MetuljmaniaContext> _options;
        protected readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public BaseDAL(IConfiguration configuration)
        {
            _options = new DbContextOptionsBuilder<MetuljmaniaContext>()
                .EnableSensitiveDataLogging()
                .UseNpgsql(configuration.GetConnectionString("DbMetuljmaniaConnectionString")).Options;
        }
    }
}

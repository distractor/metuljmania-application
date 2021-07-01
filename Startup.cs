using AutoMapper;
using Glista.Core.Models.Models;
using MetuljmaniaDatabase.Bl;
using MetuljmaniaDatabase.DAL;
using MetuljmaniaDatabase.Logic;
using MetuljmaniaDatabase.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;
using System.Globalization;
using System.Security.Principal;
using System.Text.Json.Serialization;
using System.Threading;

namespace MetuljmaniaDatabase
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            // Set configuration for appsettings.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            ConfigProvider.Configuration = Configuration;

            // Set configuration for NLog.
            var nLogFactory = LogManager.LoadConfiguration($"NLog.{env.EnvironmentName}.config");
            LogManager.Configuration = nLogFactory.Configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Basic configuration setup.
            services.Configure<IConfiguration>(Configuration);

            // Configure HTTP Context accessor and Principal.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(x => x.GetService<IHttpContextAccessor>().HttpContext.User);

            // Configure DAL.
            services.AddSingleton<IBaseDAL, BaseDAL>();

            // Configure BL.
            services.AddTransient<IEventBl, EventBl>();
            services.AddTransient<IFileBl, FileBl>();
            services.AddTransient<IPilotBl, PilotBl>();

            // Enable CORS.
            services.AddCors();

            // Add controllers.
            services.AddControllersWithViews()
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddControllers();

            // Configure AutoMapper.
            // Auto Mapper Configurations.
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<AutomapperConfig>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Metuljmania API",
                        Version = "v1",
                        Description = "Metuljmania ASP.NET Core Web API.",
                        Contact = new OpenApiContact
                        {
                            Name = "Mitja Jancic",
                            Email = "mitjajancic@gmail.com",
                        }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MetuljmaniaDatabase Api v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            // Globals CORS policy.
            app.UseCors(x =>
            {
                x.SetIsOriginAllowed(origin => true) // Allow any origin.
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); // Routes for pages.
                endpoints.MapControllers();
            });

            // Set thread culture.
            var standardizedCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            standardizedCulture.NumberFormat.NumberDecimalSeparator = Constants.DecimalSeparator;
            standardizedCulture.NumberFormat.NumberGroupSeparator = Constants.GroupSeparator;
            Thread.CurrentThread.CurrentCulture = standardizedCulture;
            Thread.CurrentThread.CurrentUICulture = standardizedCulture;
            CultureInfo.DefaultThreadCurrentCulture = standardizedCulture;
        }
    }
}

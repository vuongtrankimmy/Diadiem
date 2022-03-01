using Cores.Extension.Services;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using System.Reflection;

namespace Websites
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// Startup Construction
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterConfiguration(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAntiforgery antiforgery)
        {
            //var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            //var pathFile = $"appsettings.env.{environmentName}.yaml";
            //var appSetting = Path.Combine(AppContext.BaseDirectory, pathFile);//dev
            //Environment.SetEnvironmentVariable("TWO_APPSETTINGS", appSetting);
            app.RegisterApplication(env, antiforgery, Configuration);                        
        }
    }
}

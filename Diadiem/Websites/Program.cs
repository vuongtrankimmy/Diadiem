using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using NLog.Web;
using System.Diagnostics;
using System.Net;
using NServiceBus;
using Microsoft.AspNetCore.Server.Kestrel;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace Websites
{
    /// <summary>
    /// Program
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            try
            {
                //Activity.DefaultIdFormat = ActivityIdFormat.W3C;
                //Activity.ForceDefaultIdFormat = true;
                CreateWebHostBuilder(args)
                    .Build().Run();
            }
            catch (Exception e)
            {
                logger.Error(e, "Stopped program because of exception");
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }

        /// <summary>
        /// Create Web host Builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)      
        
                //.UseNServiceBus(context =>
                //{
                //    var config = new EndpointConfiguration("Sales.Api");
                //    config.SendOnly();
                //})
                //.AddOpenTelemetryTracing(b =>
                //{
                //    b
                //    .AddConsoleExporter()
                //    .AddSource(serviceName)
                //    .SetResourceBuilder(
                //        ResourceBuilder.CreateDefault()
                //            .AddService(serviceName: serviceName, serviceVersion: serviceVersion))
                //    .AddHttpClientInstrumentation()
                //    .AddAspNetCoreInstrumentation()
                //    .AddSqlClientInstrumentation();
                //})
                .UseContentRoot(Directory.GetCurrentDirectory())
                //.UseWebRoot("notusingwwwroot")
                .UseKestrel(options => options.AddServerHeader = false)
            .ConfigureKestrel(serverOptions =>
            {
                //serverOptions.Limits.MaxConcurrentConnections = 100;//Gets or sets the maximum number of open connections. When set to null, the number of connections is unlimited.
                //serverOptions.Limits.MaxConcurrentUpgradedConnections = 100;//Gets or sets the maximum number of open, upgraded connections. When set to null, the number of upgraded connections is unlimited. An upgraded connection is one that has been switched from HTTP to another protocol, such as WebSockets.
                //serverOptions.Limits.MaxRequestBodySize = 10 * 1024;//Gets or sets the maximum allowed size of any request body in bytes. When set to null, the maximum request body size is unlimited. This limit has no effect on upgraded connections which are always unlimited. This can be overridden per-request via IHttpMaxRequestBodySizeFeature. Defaults to 30,000,000 bytes, which is approximately 28.6MB.
                //serverOptions.Limits.MinRequestBodyDataRate =
                //    new MinDataRate(bytesPerSecond: 100,
                //        gracePeriod: TimeSpan.FromSeconds(10));
                //serverOptions.Limits.MinResponseDataRate =
                //    new MinDataRate(bytesPerSecond: 100,
                //        gracePeriod: TimeSpan.FromSeconds(10));
                //serverOptions.Listen(IPAddress.Loopback, 5000);
                //serverOptions.Listen(IPAddress.Loopback, 5001,
                //    listenOptions =>
                //    {
                //        listenOptions.UseHttps("testCert.pfx",
                //            "testPassword");
                //    });
                //serverOptions.Limits.KeepAliveTimeout =
                //    TimeSpan.FromMinutes(2);//KeepAlivePingTimeout is a TimeSpan that configures the ping timeout. If the server doesn't receive any frames, such as a response ping, during this timeout then the connection is closed. Keep alive timeout is disabled when this option is set to TimeSpan.MaxValue. The default value is 20 seconds.
                //serverOptions.Limits.RequestHeadersTimeout =
                //    TimeSpan.FromMinutes(1);
            }).UseIISIntegration()
                .ConfigureAppConfiguration(ConfigConfiguration)
                .ConfigureAppConfiguration(configurationBuilder =>
                {
                    configurationBuilder.Sources.Remove(
                    configurationBuilder.Sources.First(source =>
                    source.GetType() == typeof(EnvironmentVariablesConfigurationSource))); //remove the default one first
                    configurationBuilder.AddEnvironmentVariables();
                })
                .UseStartup<Startup>().ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseNLog();

        private static void ConfigConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder config)
        {
            var pathFile = $"appsettings.env.{ctx.HostingEnvironment.EnvironmentName}.yaml";
            config.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.env.{ctx.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddJsonFile(pathFile, optional: true, reloadOnChange: true);
            var appSetting = Path.Combine(AppContext.BaseDirectory, pathFile);//dev
            Environment.SetEnvironmentVariable("TWO_APPSETTINGS", appSetting);
        }
    }
}

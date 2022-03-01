using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using BusinessLogicLayer.Owners.App.Pages.Category;
using Contracts;
using Contracts.ImagesManager;
using Contracts.RepositoryWrapper;
using Contracts.TokenManager;
using Core.Arango;
using Cores.AntiXss;
using Cores.BadRequest;
using Cores.Exception.CustomExceptionMiddleware;
using Cores.Extension.Swagger;
using Cores.FilterAttribute;
using Cores.Jwt;
using Cores.ResponseTime;
using DataAccessLayer.Owners.App.Pages.Category;
using Entities.Extensions.Messages;
using HealthChecks.UI.Client;
using Jaeger;
using Jaeger.Reporters;
using Jaeger.Samplers;
using Jaeger.Senders.Thrift;
using LoggerService.ImagesManager;
using LoggerService.LoggerManager;
using LoggerService.TokenManager;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using NServiceBus;
using OpenTracing;
using OpenTracing.Util;
using RabbitMQ.Client;
using Repository.Query;
using Repository.RepositoryWrapper;
using static Thrift.Server.TThreadPoolAsyncServer;

namespace Cores.Extension.Services
{
    /// <summary>
    /// Service Extension
    /// </summary>
    public static class ServicesExtension
    {
        public static string GetEnvironmentVariable(string name, string defaultValue)
                    => Environment.GetEnvironmentVariable(name,EnvironmentVariableTarget.Process) ?? defaultValue;
        #region Newtonsoft Json
        public static void NewtonsoftJson(this IServiceCollection services)
        {
            #region Cors Policy
            services.AddControllers();
#pragma warning disable ASP5001 // Type or member is obsolete
            _ = services.AddMvc(
                options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }
#pragma warning disable CS0618 // Type or member is obsolete
            ).SetCompatibilityVersion(version: CompatibilityVersion.Latest);
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore ASP5001 // Type or member is obsolete
            services.AddMvc().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ContractResolver =
                    new DefaultContractResolver();//Fixed Swagger hiển thị kiểu CamelCase (convert CamelCase-->PascalCase)
            }).ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problems = new CustomBadRequest(context);

                    return new BadRequestObjectResult(problems);
                };
            });
            #endregion
        }
        #endregion
        #region Hsts
        /// <summary>
        ///The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        ///Enforce HTTPS in ASP.NET Core.https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-6.0&tabs=visual-studio
        /// </summary>
        /// <param name="services"></param>
        public static void Hsts(this IServiceCollection services)
        {
            #region Hsts
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                //options.ExcludedHosts.Add("example.com");
                //options.ExcludedHosts.Add("www.example.com");
            });

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
                options.HttpsPort = 5001;
            });
            #endregion
        }
        #endregion
        #region Configure Cors
        //https://docs.microsoft.com/en-us/aspnet/core/performance/caching/middleware?view=aspnetcore-6.0
        //UseCors must be called before UseResponseCaching when using CORS middleware.
        //configure CORS is a mechanism that gives rights to the user to access resources from the server on a different domain
        /// <summary>
        /// Configure Cors
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            #region Cors Policy
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .SetIsOriginAllowed(_ => true);
                //.AllowAnyOrigin();
            }));
            #endregion
        }
        #endregion
        #region ConfigureIIS
        //IIS integration which will help us with the IIS deployment
        /// <summary>
        /// Configure IIS Intergration
        /// </summary>
        /// <param name="services"></param>
        // ReSharper disable once InconsistentNaming
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(_ =>
            {
            });
        }
        #endregion
        #region Logger Service
        /// <summary>
        /// Configure Loggers Service
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddSingleton<IImagesManager, ImagesManager>();            
        }
        public static void AppLoggerService(this IApplicationBuilder app)
        {
            app.UseMiddleware<ResponseTimeMiddleware>();
        }
        #endregion
        #region Custom Exception
        /// <summary>
        /// Configure Custom Exception Middleware
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
        public static void ConfigureExceptionHandle(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { error = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));
        }
        #endregion
        #region ArangoDB
        /// <summary>
        /// Configure ArangoDB Context
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureArangoDbContext(this IServiceCollection services, IConfiguration config)
        {
            #region Database connection
            var environmentName = GetEnvironmentVariable("ARANGO_SERVER", config.GetConnectionString("Arango"));
            services.AddArango(environmentName);
            #endregion
        }
        #endregion
        #region App Setting
        public static void ConfigureAppSetting(this IServiceCollection services, IConfiguration config)
        {
            #region Database connection
            var appIdentitySettings = config.GetSection("AppIdentitySettings");
            var appDBSettings = config.GetSection("AppDBSettings");
            var tokenManagement = config.GetSection("TokenManagement");
            var appsAuthenticate = config.GetSection("AppsAuthenticate");
            var domainSettings = config.GetSection("DomainSettings");

            services.Configure<AppIdentitySettings>(appIdentitySettings);
            services.Configure<AppDBSettings>(appDBSettings);
            services.Configure<TokenManagement>(tokenManagement);
            services.Configure<AppsAuthenticate>(appsAuthenticate);
            services.Configure<AppDomainSettings>(domainSettings);
            #endregion
        }
        #endregion
        #region Authentication Jwt Bearer
        /// <summary>
        /// AuthenticationJwt Bearer
        /// Security and Using JWT
        ///JSON Web Tokens(JWT) are becoming more popular by the day in web development.It is very easy to implement JWT Authentication due to the.NET Core’s built-in support.JWT is an open standard and it allows us to transmit the data between a client and a server as a JSON object in a secure way.
        ///</summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void AuthenticationJwtBearer(this IServiceCollection services, IConfiguration config)
        {
            #region Authentication
            var token = config.GetSection("tokenManagement").Get<TokenManagement>();
            services.AddSingleton(token);
            services.AddAuthentication(x =>
            {
                x.DefaultScheme = "Cookies";
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddCookie("Cookies")
                .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = token.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.Secret)),
                    ValidAudience = token.Audience,
                    ValidateAudience = false,
                    ValidateLifetime = false//here we are saying that we don't care about the token's expiration date

                };
            });
            #endregion       
        }
        public static void ConfigureAuthenticationJwtBearer(this IApplicationBuilder app, IConfiguration config)
        {
            app.UseMiddleware<JwtMiddleware>();
            app.UseCookiePolicy();
            app.UseSession();
            app.Use(async (context, next) =>
            {
                var jwtToken = context.Session.GetString("JwtToken");
                if (!string.IsNullOrEmpty(jwtToken))
                {
                    context.Request.Headers.Clear();
                    context.Request.Headers.Add("Authorization", "Bearer " + jwtToken);
                }
                else
                {
                    var token1 = context.Request.Headers.TryGetValue("Authorization", out StringValues token);
                    var token3 = context.Request.Query.TryGetValue("access_token", out StringValues token2);
                    if (token1)
                    {
                        // pull token from header or querystring; websockets don't support headers so fallback to query is required
                        //var tokenValue = token.FirstOrDefault() 
                        //?? token2.FirstOrDefault();
                        var tokenValue = token.FirstOrDefault()
                        ?? "";
                        const string prefix = "Bearer ";
                        // remove prefix of header value
                        if (tokenValue?.StartsWith(prefix) ?? false)
                        {
                            //accessToken = tokenValue.Substring(prefix.Length);//
                            jwtToken = tokenValue[prefix.Length..];
                        }
                        else
                        {
                            jwtToken = tokenValue;
                        }
                        if (jwtToken != "")
                        {
                            context.Request.Headers.Clear();
                            context.Request.Headers.Add("Authorization", "Bearer " + jwtToken);
                            context.Session.SetString("JwtToken", jwtToken);

                            //try
                            //{
                            //    var tokenManagement = config.GetSection("tokenManagement").Get<TokenManagement>();
                            //    if (tokenManagement != null && jwtToken != null && jwtToken != "")
                            //    {
                            //        var tokenHandler = new JwtSecurityTokenHandler();
                            //        var key = Encoding.UTF8.GetBytes(tokenManagement.Secret);
                            //        tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters
                            //        {
                            //            ValidateIssuerSigningKey = true,
                            //            IssuerSigningKey = new SymmetricSecurityKey(key),
                            //            ValidateIssuer = false,
                            //            ValidateAudience = false,
                            //            // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                            //            ClockSkew = TimeSpan.Zero
                            //        }, out SecurityToken validatedToken);

                            //        var jwtSecurityToken = (JwtSecurityToken)validatedToken;
                            //        var user = jwtSecurityToken.Claims;

                            //        //Write authentication information to facilitate the use of business classes
                            //        var claimsIdentity = new ClaimsIdentity(user);
                            //        Thread.CurrentPrincipal = new ClaimsPrincipal(claimsIdentity);

                            //        // attach user to context on successful jwt validation
                            //        context.Items["User"] = user;
                            //    }
                            //}
                            //catch
                            //{
                            //    // do nothing if jwt validation fails
                            //    // user is not attached to context so request won't have access to secure routes
                            //    throw;
                            //}
                        }
                    }
                }
                await next(context);
            });
            app.UseAuthentication();
            app.UseAuthorization();
        }
        #endregion
        #region Session
        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });
        }
        #endregion
        #region Response Caching
        //Phải khai báo sau Cors
        public static void ConfigurationResponseCaching(this IServiceCollection services)
        {
            services.AddResponseCaching(options =>
            {
                options.MaximumBodySize = 1024;
                options.UseCaseSensitivePaths = true;
            });
        }
        public static void AppConfigurationResponseCaching(this IApplicationBuilder app)
        {
            app.UseResponseCaching();
            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(10)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                await next(context);
            });
        }
        #endregion
        #region Scoped
        /// <summary>
        /// Adds the scoped.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddScoped(this IServiceCollection services)
        {
            services.AddScoped<ModelValidationAttribute>();
        }
        #endregion
        #region Language
        public static void ConfigureLanguage(this IServiceCollection services)
        {
            services.AddLocalization();

            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en-US"),
                        new CultureInfo("vi-VN")
                    };

                    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                    options.RequestCultureProviders = new IRequestCultureProvider[] { new RouteDataRequestCultureProvider { Options = new RequestLocalizationOptions() } };
                });
        }
        #endregion
        #region AutoMapper
        /// <summary>
        /// Adds the scoped.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddAutoMapper(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(AccountProfile));
        }
        #endregion
        #region Environment
        public static void AddEnvironment(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Development environment code
            }
            else if (env.IsStaging())
            {
                // Staging environment code
            }
            else if (env.IsProduction())
            {
                // Code for all other environments
            }
        }
        #endregion
        #region Transient Service
        /// <summary>
        /// Configure Loggers Service
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureTransientService(this IServiceCollection services)
        {
            services.AddTransient<ITokenManager, TokenManager>();
            services.AddTransient<IQuery, Query>();
            services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
            services.AddTransient<ICategoryDAL, CategoryDAL>();
        }
        #endregion
        #region Forgery Option Service
        public static void AbpAntiForgeryOptionService(this IServiceCollection services)
        {
            //https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-6.0
            services.AddAntiforgery(options =>
            {
                // Set Cookie properties using CookieBuilder properties†.
                options.FormFieldName = "Antiforgery";
                options.HeaderName = "XSRF-TOKEN";
                options.SuppressXFrameOptionsHeader = false;
            });
            services.AddControllersWithViews(options =>
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
        }

        public static void AddAntiforgery(this IApplicationBuilder app, IAntiforgery antiforgery)
        {
            app.Use(next => context =>
            {
                string path = context.Request.Path.Value;

                if (
                    string.Equals(path, "/", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(path, "/index.html", StringComparison.OrdinalIgnoreCase))
                {
                    // The request token can be sent as a JavaScript-readable cookie, 
                    // and Angular uses it by default.
                    var tokens = antiforgery.GetAndStoreTokens(context);
                    context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                        new CookieOptions() { HttpOnly = false });
                }
                return next(context);
            });
        }
        #endregion
        #region Anti XSS
        public static void AntiXss(this IApplicationBuilder app)
        {
            app.UseMiddleware<AntiXssMiddleware>();
        }
        #endregion
        #region Gzip
        public static void ConfigureGzip(this IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                            {
                               "image/svg+xml",
                               "application/atom+xml"
                            });
            });
        }
        #endregion
        #region GRPC
        public static void ConfigureGRPC(this IServiceCollection services)
        {

        }
        #endregion
        #region Zipkin
        public static void AddZipkin(this IServiceCollection services)
        {
            //services.AddOpenTelemetryTracing(builder => builder
            //     .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(Program.EndpointName))
            //     .AddAspNetCoreInstrumentation(opt => opt.Enrich = (activity, key, value) =>
            //     {
            //         Console.WriteLine($"Got an activity named {key}");
            //     })
            //     .AddSqlClientInstrumentation(opt => opt.SetDbStatementForText = true)
            //     .AddNServiceBusInstrumentation()
            //     .AddZipkinExporter(o =>
            //     {
            //         o.Endpoint = new Uri("http://localhost:9411/api/v2/spans");
            //     })
            //     .AddJaegerExporter(c =>
            //     {
            //         c.AgentHost = "localhost";
            //         c.AgentPort = 6831;
            //     })
            // );
        }
        #endregion
        #region Jaeger
        public static void AddJaeger(this IServiceCollection services)
        {
            //services.AddOpenTracing();
            services.AddSingleton<ITracer>(serviceProvider =>
            {
                string serviceName = Assembly.GetEntryAssembly().GetName().Name;

                ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

                ISampler sampler = new ConstSampler(sample: true);

                ITracer tracer = new Tracer.Builder(serviceName)
                    .WithLoggerFactory(loggerFactory)
                    .WithSampler(sampler)
                    .Build();

                GlobalTracer.Register(tracer);

                return tracer;
            });
        }
        #endregion
        #region NServiceBus
        private static async Task SetupNServiceBus(this IServiceCollection services)
        {

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

            }

            //var endpointConfiguration = new EndpointConfiguration("ClientUI");
            //endpointConfiguration.MakeInstanceUniquelyAddressable("Client");
            //var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();

            //var connectionFactory = new ConnectionFactory()
            //{
            //    HostName = "127.0.0.1",
            //    Port = 15672,
            //    UserName = "guest",
            //    Password = "guest",
            //    VirtualHost = "/"
            //};
            //using (IConnection connection = connectionFactory.CreateConnection())
            //{
            //    //transport.ConnectionString("host=localhost:15672; username=diadiem;password =diadiem@2019").UseDirectRoutingTopology();



            //    var routing = transport.Routing();
            //    routing.RouteToEndpoint(typeof(RequestMessage), "ServerSide");
            //}
            //var _endpointInstance = await NServiceBus.Endpoint.Start(endpointConfiguration)
            //    .ConfigureAwait(false);

            //services.AddSingleton(_endpointInstance);
        }
        #endregion
        #region Rate Limit Request
        public static void ConfigurationRateLimitResponse(this IServiceCollection services, IConfiguration configuration)
        {
            // needed to load configuration from appsettings.json
            services.AddOptions();

            // needed to store rate limit counters and ip rules
            services.AddMemoryCache();

            //load general configuration from appsettings.json
            services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));
            services.AddDistributedRateLimiting<AsyncKeyLockProcessingStrategy>();
            // inject counter and rules stores
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            // https://github.com/aspnet/Hosting/issues/793
            // the IHttpContextAccessor service is not registered by default.
            // the clientId/clientIp resolvers use it.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // configuration (resolvers, counter key builders)
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }
        #endregion
        public static void AddConfigureHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks().AddCheck("Diadiem",
                () =>
                {
                    return HealthCheckResult.Degraded("The check of the service did not work well");
                }
            ).AddCheck("Database",
            () => HealthCheckResult.Healthy("The check of the database worked."));
            //services.AddHealthChecksUI().AddInMemoryStorage();
        }
        public static void AppCsp(this IApplicationBuilder app)
        {
            //https://letienthanh0212.medium.com/how-to-secure-your-net-core-web-application-with-nwebsec-c705fb5daf4b
            app.UseCsp(options =>
            {
                options.BlockAllMixedContent()
                //.ScriptSources(s => s.Self())
                .StyleSources(s => s.Self())
                //.StyleSources(s => s.UnsafeInline())
                .FontSources(s => s.Self())
                .FormActions(s => s.Self())
                .FrameAncestors(s => s.Self())
                .ImageSources(s => s.Self());
            });
            app.UseXfo(option =>
            {
                option.SameOrigin();
            });
            app.UseXXssProtection(option =>
            {
                option.EnabledWithBlockMode();
            });
            app.UseXContentTypeOptions();
            app.UseReferrerPolicy(opts => opts.NoReferrer());
            app.Use(async (context, next) =>
            {
                if (!context.Response.Headers.ContainsKey("Contact"))
                {
                    context.Response.Headers.Add("Contact", "Vuong Tran Kim My");
                }
                if (!context.Response.Headers.ContainsKey("Tel"))
                {
                    context.Response.Headers.Add("Tel", "(084) 70-778-2689");
                }
                if (!context.Response.Headers.ContainsKey("Email"))
                {
                    context.Response.Headers.Add("Email", "trankimmyvuong@gmail.com");
                }
                if (!context.Response.Headers.ContainsKey("Skype"))
                {
                    context.Response.Headers.Add("Skype", "vuong.trankimmy");
                }
                await next();
            });
        }
        #region Register All Configuration
        public static void RegisterConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            #region config 3.0
            //3.0
            //fix KindValue//Microsoft.AspNetCore.Mvc.NewtonsoftJson
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.ConfigureSession();
            services.Hsts();
            services.NewtonsoftJson();
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.ConfigureLoggerService();
            services.ConfigureArangoDbContext(Configuration);
            services.AuthenticationJwtBearer(Configuration);
            services.AddSwagger(Configuration);
            services.AddScoped();
            services.ConfigureTransientService();
            services.AddAutoMapper();
            services.ConfigureLanguage();
            services.AbpAntiForgeryOptionService();
            services.ConfigureGzip();
            services.ConfigurationResponseCaching();
            //services.ConfigurationRateLimitResponse(Configuration);//tam tat: 2022.01.21
            //services.SetupNServiceBus().GetAwaiter().GetResult();
            services.AddConfigureHealthCheck();
            #endregion
            #region Connect to appsettings.json
            services.ConfigureAppSetting(Configuration);
            #endregion
        }
        #endregion
        #region Register All Application
        public static void RegisterApplication(this IApplicationBuilder app, IWebHostEnvironment env, IAntiforgery antiforgery, IConfiguration Configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (env.IsProduction() || env.IsStaging())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.AppCsp();
            app.UseRouting();
            app.ConfigureCustomExceptionMiddleware();
            app.UseCors("CorsPolicy");
            app.AppConfigurationResponseCaching();
            app.ConfigureAuthenticationJwtBearer(Configuration);
            //3.0
            app.AddAntiforgery(antiforgery);
            app.AntiXss();
            app.UseCustomSwagger();
            app.UseResponseCompression();
            //3.0 - Required for routes
            app.ConfigureExceptionHandle();
            //app.UseIpRateLimiting();//tam tat: 2022.01.21
            app.AppLoggerService();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/quickhealth", new HealthCheckOptions()
                {
                    Predicate = _ => false
                });
                endpoints.MapHealthChecks("/health/service", new HealthCheckOptions()
                {
                    Predicate = reg => reg.Tags.Contains("service"),
                    ResponseWriter= UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                //endpoints.MapHealthChecksUI();
                endpoints.MapControllers();
            });
        }
        #endregion
    }
}

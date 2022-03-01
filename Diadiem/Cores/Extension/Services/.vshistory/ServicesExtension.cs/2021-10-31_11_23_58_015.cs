using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Contracts;
using Cores.Exception.CustomExceptionMiddleware;
using Cores.FilterAttribute;
using LoggerService.LoggerManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Cores.Extension.Services
{
    /// <summary>
    /// Service Extension
    /// </summary>
    public static class ServicesExtension
    {
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
                    .SetIsOriginAllowed(_ => true)
                    .AllowCredentials();
                //.AllowAnyOrigin();
            }));
            #endregion
        }

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

        /// <summary>
        /// Configure Loggers Service
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

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

        /// <summary>
        /// Configure ArangoDB Context
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureArangoDbContext(this IServiceCollection services, IConfiguration config)
        {
            #region Database connection
            services.AddArango(config.GetConnectionString("Arango"));
            #endregion
        }

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
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = token.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)),
                    ValidAudience = token.Audience,
                    ValidateAudience = false
                };
            });
            #endregion       
        }

        /// <summary>
        /// Adds the scoped.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddScoped(this IServiceCollection services)
        {
            services.AddScoped<ModelValidationAttribute>();
        }

        /// <summary>
        /// Configure Loggers Service
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureTransientService(this IServiceCollection services)
        {
            services.AddTransient<IQuery, Query>();
            //services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
            //services.AddTransient<IAccountDal, AccountDal>();
            //services.AddTransient<IProductDal, ProductDal>();
            //services.AddTransient<ICategoryDal, CategoryDal>();
            //services.AddTransient<ILocationDal, LocationDal>();
        }

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
                    options.RequestCultureProviders = new IRequestCultureProvider[] { new RouteDataRequestCultureProvider {Options = new RequestLocalizationOptions()} };
                });
        }

        /// <summary>
        /// Adds the scoped.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AccountProfile));
        }


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


    }
}

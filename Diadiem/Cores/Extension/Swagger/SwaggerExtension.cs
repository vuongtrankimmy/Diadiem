using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Cores.Extension.Swagger
{
    /// <summary>
    /// Swagger Extension
    /// </summary>
    public static class SwaggerExtension
    {
        private static string _document;
        private static string _swaggerName;
        private static string _version;
        private static string _title;
        private static string _termsOfService;
        private static string _contactName;
        private static string _contactEmail;
        private static string _license;
        private static Uri _licenseUrl;
        private static string _swaggerEndpoint;
        private static string _injectStylesheet;
        private static string _injectJavascript;
        private static string _name;
        private static string _documentTitle;
        private static string _routeTemplate;
        /// <summary>
        /// Add Swagger
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void AddSwagger(this IServiceCollection services, IConfiguration config)
        {
            _document = config.GetSection("DomainSettings:document").Value;
            _swaggerName = config.GetSection("Swagger:SwaggerName").Value;
            _version = config.GetSection("Swagger:SwaggerDoc:Version").Value;
            _title = config.GetSection("Swagger:SwaggerDoc:Title").Value;
            _termsOfService = config.GetSection("Swagger:SwaggerDoc:TermsOfService").Value;
            _contactName = config.GetSection("Swagger:SwaggerDoc:Contact:Name").Value;
            _contactEmail = config.GetSection("Swagger:SwaggerDoc:Contact:Email").Value;
            _license = "© " + config.GetSection("Swagger:SwaggerDoc:License:Name").Value;
            _licenseUrl = new Uri(String.Format(_document, config.GetSection("Swagger:SwaggerDoc:License:Url").Value));
            _swaggerEndpoint = config.GetSection("Swagger:UseSwaggerUI:SwaggerEndpoint").Value;
            _injectStylesheet = config.GetSection("Swagger:UseSwaggerUI:InjectStylesheet").Value;
            _injectJavascript = config.GetSection("Swagger:UseSwaggerUI:InjectJavascript").Value;
            _name = config.GetSection("Swagger:UseSwaggerUI:Name").Value;
            _documentTitle = config.GetSection("Swagger:UseSwaggerUI:DocumentTitle").Value;
            _routeTemplate = "swagger/{documentName}/swagger.json";

            #region Users ChangeLogs
            var DomainDoc_users = (_document + _swaggerName + "/").ToLower();
            var changeLogs_users = "<br>***Change Logs*** <br><br>→ **[`v1.0 (20/08/2020)`](" + DomainDoc_users + "changelog/changelog_v1.0.html)**";
            var WhatNew_users = DomainDoc_users + "what-new/what-new.html";
            #endregion
            var appName = Assembly.GetEntryAssembly().GetName().Name;
            var version = Assembly.GetEntryAssembly().GetName().Version.ToString();
            #region //API Swagger 4.0.1
            services.AddSwaggerGen(swagger =>
            {
                //swagger.CustomSchemaIds(type => type.FullName);
                swagger.SwaggerGeneratorOptions.IgnoreObsoleteActions = true;
                //////Add Operation Specific Authorization///////
                //swagger.OperationFilter<TpSecurity_Authentication>();
                ////////////////////////////////////////////////

                swagger.SwaggerDoc(_swaggerName, new OpenApiInfo
                {
                    Version = _version+ " → " + version+"",
                    Title = _title,
                    Description = changeLogs_users,
                    TermsOfService = new Uri(string.Format(_document, _termsOfService)),
                    Contact = new OpenApiContact
                    {
                        Name = _contactName,
                        Email = _contactEmail
                        //Url = new Uri(String.Format(Configuration.GetSection("DomainSettings:document").Value,Configuration.GetSection("Swagger:SwaggerDoc:Contact:Url").Value)),
                    }
                    ,
                    License = new OpenApiLicense
                    {
                        Name = _license,
                        Url = _licenseUrl
                    }
                });
                //swagger.DescribeAllEnumsAsStrings();
                //swagger.DescribeStringEnumsInCamelCase();
                swagger.EnableAnnotations();
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swagger.IncludeXmlComments(xmlPath);
                swagger.IgnoreObsoleteProperties();

                // add JWT Authentication
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                swagger.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, Array.Empty<string>()}
                });

                // add Basic Authentication
                var basicSecurityScheme = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    Reference = new OpenApiReference { Id = "BasicAuth", Type = ReferenceType.SecurityScheme }
                };
                swagger.AddSecurityDefinition(basicSecurityScheme.Reference.Id, basicSecurityScheme);
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {basicSecurityScheme, Array.Empty<string>()}
                });
            });
            #endregion
        }

        /// <summary>
        /// Use Custom Swagger
        /// </summary>
        /// <param name="app"></param>
        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            #region Swagger
            app.UseReDoc(c =>
            {
                c.SpecUrl(String.Format(_swaggerEndpoint, _swaggerName));
                c.EnableUntrustedSpec();
                c.ScrollYOffset(10);
                c.HideHostname();
                c.HideDownloadButton();
                c.ExpandResponses("200,201");
                c.RequiredPropsFirst();
                c.NoAutoAuth();
                c.PathInMiddlePanel();
                c.HideLoading();
                c.NativeScrollbars();
                c.DisableSearch();
                c.OnlyRequiredInSamples();
                c.SortPropsAlphabetically();
            });
            app.UseSwagger(c => c.SerializeAsV2 = false);
            app.UseSwagger(c =>
            {
                c.RouteTemplate = _routeTemplate;
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.Servers = new List<OpenApiServer>
                        {new() {Url = $"{httpReq.Scheme}://{httpReq.Host.Value}"}};
                });
            });
            app.UseSwaggerUI(c =>
            {
                c.InjectStylesheet(_injectStylesheet);
                c.InjectJavascript(_injectJavascript);
                c.SwaggerEndpoint(
                    String.Format(_swaggerEndpoint, _swaggerName),
                    _name);
                c.DocumentTitle = _documentTitle;
                //c.RoutePrefix = Configuration.GetSection("Swagger:UseSwaggerUI:RoutePrefix").Value;
                //c.DocExpansion(DocExpansion.None);
                //c.DefaultModelExpandDepth(2);
                //c.DefaultModelRendering(ModelRendering.Model);
                //c.DefaultModelsExpandDepth(-1);
                c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.DocExpansion(DocExpansion.List);
                c.EnableDeepLinking();
                c.EnableFilter();
                //c.MaxDisplayedTags(5);
                c.ShowExtensions();
                c.EnableValidator();

                //c.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Put, SubmitMethod.Delete);
                c.RoutePrefix = string.Empty;
            });
            #endregion

            #region Default Page
            DefaultFilesOptions defaultFile = new();
            defaultFile.DefaultFileNames.Clear();
            defaultFile.DefaultFileNames.Add("swagger/index.html");
            app.UseDefaultFiles(defaultFile);
            app.UseStaticFiles();
            #endregion
        }
    }
}

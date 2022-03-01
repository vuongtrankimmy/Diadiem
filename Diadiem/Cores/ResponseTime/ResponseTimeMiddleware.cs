using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.ResponseTime
{
    /// <summary>
    /// tries to measure request processing time
    /// </summary>
    public class ResponseTimeMiddleware
    {
        // Name of the Response Header, Custom Headers starts with "X-"  
        private const string ResponseHeaderResponseTime = "X-Response-Time-ms";

        // Handle to the next Middleware in the pipeline  
        private readonly RequestDelegate _next;

        ///<inheritdoc/>
        public ResponseTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        ///<inheritdoc/>
        public Task InvokeAsync(HttpContext context)
        {
            // skipping measurement of non-actual work like OPTIONS
            if (context.Request.Method == "OPTIONS")
                return _next(context);

            // Start the Timer using Stopwatch  
            var watch = new Stopwatch();
            watch.Start();

            context.Response.OnStarting(() => {
                // Stop the timer information and calculate the time   
                watch.Stop();
                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
                // Add the Response time information in the Response headers.   
                context.Response.Headers[ResponseHeaderResponseTime] = responseTimeForCompleteRequest.ToString();

                var logger = context.RequestServices.GetService<ILoggerManager>();
                string fullUrl = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";
                var log = $"[Performance] Request to {fullUrl} took {responseTimeForCompleteRequest} ms";
                logger?.LogDebug(log);
                Console.WriteLine(log);
                return Task.CompletedTask;
            });

            // Call the next delegate/middleware in the pipeline   
            return _next(context);
        }
    }
}

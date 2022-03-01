using System.Net;
using System.Threading.Tasks;
using Contracts;
using Entities.ExtendedModels.GlobalErrorHandling;
using Microsoft.AspNetCore.Http;

namespace Cores.Exception.CustomExceptionMiddleware
{
    /// <summary>
    /// Exception Middle
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        /// <summary>
        /// Exception construction
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
        }
        /// <summary>
        /// Invoke Async
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext)
                    //.ConfigureAwait(false)
                    ;
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex.Message).ConfigureAwait(false);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context,string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                //Message = "Internal Server Error from the custom middleware."
                Message =message
            }.ToString());
        }
    }
}

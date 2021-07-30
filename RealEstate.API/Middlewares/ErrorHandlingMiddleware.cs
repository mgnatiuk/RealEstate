using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RealEstate.Application.Exceptions;

namespace RealEstate.API.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException notFoundException)
            {
                _logger.LogError(notFoundException.Message);
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (Exception exception)
            {
                string errorGuid = Guid.NewGuid().ToString();

                _logger.LogError(errorGuid, exception.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync($"Error guid: {errorGuid}. \n{exception.Message}");
            }
        }
    }
}

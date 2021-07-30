using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace RealEstate.API.Middlewares
{
    public class LongTimeRequestMiddleware : IMiddleware
    {
        private readonly ILogger<LongTimeRequestMiddleware> _logger;
        private Stopwatch _watch;

        public LongTimeRequestMiddleware(ILogger<LongTimeRequestMiddleware> logger)
        {
            _logger = logger;
            _watch = new Stopwatch();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _watch.Start();

            await next.Invoke(context);

            _watch.Stop();

            var milliseconds = _watch.ElapsedMilliseconds;

            if(milliseconds / 1000 > 4)
            {
                var message = $"Request [{context.Request.Method}] at {context.Request.Path} took {milliseconds} ms.";
                _logger.LogInformation(message);
            }
        }
    }
}

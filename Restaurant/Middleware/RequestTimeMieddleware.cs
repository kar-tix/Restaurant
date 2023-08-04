using Microsoft.AspNetCore.Http;
using RestaurantAPI.Exceptions;
using System.Diagnostics;

namespace RestaurantAPI.Middleware
{
    public class RequestTimeMieddleware : IMiddleware
    {
        public Stopwatch _stopWatch;
        private readonly ILogger<RequestTimeMieddleware> _logger;
        public RequestTimeMieddleware(ILogger<RequestTimeMieddleware> logger)
        {
            _stopWatch = new Stopwatch();
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopWatch.Start();
            await next.Invoke(context);
            _stopWatch.Stop();

            var elapsedMilliseconds = _stopWatch.ElapsedMilliseconds;
            if(elapsedMilliseconds/1000 > 4)
            {
                var message = $"Request [{context.Request.Method}] at {context.Request.Path} took {elapsedMilliseconds} ms";
                _logger.LogInformation(message);
            }
        }
    }
}

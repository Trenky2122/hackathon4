using EntBa_Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EntBa_Core.Middleware
{
    /// <summary>
    /// Middleware for trace logging of requests
    /// </summary>
    public sealed class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;
        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = $"{context.Request.Method}:{context.Request.Path}{context.Request.QueryString}";
            _logger.LogTraceRequestEnter(path);
            await _next(context);
            _logger.LogTraceRequestExit(path);
        }
    }
}
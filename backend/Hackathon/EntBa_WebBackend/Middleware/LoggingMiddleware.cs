using EntBa_Core.Extensions;
using HttpMultipartParser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace EntBa_WebBackend.Middleware;

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
        context.Request.EnableBuffering();
        var path = $"{context.Request.Method}:{context.Request.Path}{context.Request.QueryString}";
        await _next(context);
        _logger.LogTraceRequestExit(path);
    }
}

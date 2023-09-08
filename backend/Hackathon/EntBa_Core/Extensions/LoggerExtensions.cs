using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EntBa_Core.Extensions
{
    public static class LoggerExtensions
    {
        #region Private fields
        private static readonly JsonSerializerSettings JsonSettings = new() { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        private static int _characterLimitPerObject = int.MaxValue; // default values, because we want to limiting be explicitly turned on if wanted in program
        private static int _characterLimitPerPath = int.MaxValue;
        private static bool _extendedLogging = true;
        #endregion

        #region Initialization
        /// <summary>
        /// Sets properties that specify if logs should occur and limits for object and path lengths
        /// </summary>
        /// <param name="extendedLogging">Specifies if trace logs should be sent (default true)</param>
        /// <param name="characterLimitPerObject">Specifies maximal length of serialized args and ret object (counts separately) (default int.MaxValue)</param>
        /// <param name="characterLimitPerPath">Maximal length of logged paths (default int.MaxValue)</param>
        public static void SetProperties(bool extendedLogging, int characterLimitPerObject, int characterLimitPerPath)
        {
            _extendedLogging = extendedLogging;
            _characterLimitPerObject = characterLimitPerObject;
            _characterLimitPerPath = characterLimitPerPath;
        }
        #endregion

        #region Trace Method
        /// <summary>
        /// Logs entering method in 'Enter: {methodName}, -args: {args}' format, also limits log length if limits are set
        /// </summary>
        /// <param name="logger">Logger instance to be logged with</param>
        /// <param name="methodName">Name of method to be logged</param>
        /// <param name="args">Optional method arguments to be logged</param>
        /// <param name="force">If true, ignores extended logging setting and always logs (logger settings like minimum level still apply)</param>
        public static void LogTraceEnter(this ILogger logger, [CallerMemberName] string methodName = "", object? args = null, bool force = false)
        {
            if (!_extendedLogging && !force)
                return;
            string argsMessage = LimitLogText(JsonConvert.SerializeObject(args, JsonSettings), _characterLimitPerObject);
            logger.LogTrace("Enter: {methodName}, -args: {@argsMessage}", methodName, argsMessage);
        }

        /// <summary>
        /// Logs exiting method in 'Exit: {methodName}, -args: {args}, -ret: {ret}' format, also limits log length if limits are set
        /// </summary>
        /// <param name="logger">Logger instance to be logged with</param>
        /// <param name="methodName">Name of method to be logged</param>
        /// <param name="args">Optional method arguments to be logged</param>
        /// <param name="force">If true, ignores extended logging setting and always logs (logger settings like minimum level still apply)</param>
        public static void LogTraceExit(this ILogger logger, [CallerMemberName] string methodName = "", object? args = null, object? ret = null, bool force = false)
        {
            if (!_extendedLogging && !force)
                return;
            string argsMessage = LimitLogText(JsonConvert.SerializeObject(args, JsonSettings), _characterLimitPerObject);
            string retMessage = LimitLogText(JsonConvert.SerializeObject(ret, JsonSettings), _characterLimitPerObject);
            logger.LogTrace("Exit: {methodName}, -args: {@argsMessage}, -ret: {@retMessage}", methodName, argsMessage, retMessage);
        }

        /// <summary>
        /// Execute method and log entering and exiting and return value
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="logger">Logger</param>
        /// <param name="method">Method to be executed</param>
        /// <param name="methodName">Method name</param>
        /// <param name="args">Optional method arguments to log</param>
        /// <param name="force">Whether to ignore extended logging settings</param>
        /// <returns></returns>
        public static T LogTrace<T>(this ILogger logger, Func<T> method, [CallerMemberName] string methodName = "", object? args = null, bool force = false)
        {
            logger.LogTraceEnter(methodName, args, force);
            T result = method();
            logger.LogTraceExit(methodName, args, result, force);
            return result;
        }

        /// <summary>
        /// Execute method and return its return value
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="method">Method to be executed</param>
        /// <param name="methodName">Method name</param>
        /// <param name="args">Optional method arguments to log</param>
        /// <param name="force">Whether to ignore extended logging settings</param>
        public static void LogTrace(this ILogger logger, Action method, [CallerMemberName] string methodName = "",
            object? args = null, bool force = false)
        {
            logger.LogTraceEnter(methodName, args, force);
            method();
            logger.LogTraceExit(methodName, args, force: force);
        }

        /// <summary>
        /// Execute method and asynchronously await Task it returns
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="method">Method to be executed</param>
        /// <param name="methodName">Method name</param>
        /// <param name="args">Optional method arguments to log</param>
        /// <param name="force">Whether to ignore extended logging settings</param>
        /// <returns></returns>
        public static async Task LogTraceAwaitAsync(this ILogger logger, Func<Task> method,
            [CallerMemberName] string methodName = "",
            object? args = null, bool force = false)
        {
            logger.LogTraceEnter(methodName, args, force);
            await method();
            logger.LogTraceExit(methodName, args, force: force);
        }

        /// <summary>
        /// Execute method, asynchronously await task it returns and return its return value
        /// </summary>
        /// <typeparam name="T">Return type of task</typeparam>
        /// <param name="logger">Logger</param>
        /// <param name="method">Method to be executed</param>
        /// <param name="methodName">Method name</param>
        /// <param name="args">Optional method arguments to log</param>
        /// <param name="force">Whether to ignore extended logging settings</param>
        /// <returns></returns>
        public static async Task<T> LogTraceAwaitAsync<T>(this ILogger logger, Func<Task<T>> method,
            [CallerMemberName] string methodName = "",
            object? args = null, bool force = false)
        {
            logger.LogTraceEnter(methodName, args, force);
            var result = await method();
            logger.LogTraceExit(methodName, args, result, force);
            return result;
        }

        /// <summary>
        /// Calls logger.LogTrace if extended logging is turned on
        /// </summary>
        /// <param name="logger">Logger instance to be logged with</param>
        /// <param name="message">Message to be logged</param>
        /// <param name="args">Log params</param>
        public static void LogTraceExtended(this ILogger logger, string message, params object?[] args)
        {
            if (!_extendedLogging)
                return;
            logger.LogTrace(message, args);
        }
        #endregion

        #region Debug
        /// <summary>
        /// Calls logger.LogDebug if extended logging is turned on
        /// </summary>
        /// <param name="logger">Logger instance to be logged with</param>
        /// <param name="message">Message to be logged</param>
        /// <param name="args">Log params</param>
        public static void LogDebugExtended(this ILogger logger, string message, params object?[] args)
        {
            if (!_extendedLogging)
                return;
            logger.LogDebug(message, args);
        }
        #endregion

        #region Error
        /// <summary>
        /// Logs exception and limits log length if set
        /// </summary>
        /// <param name="logger">Logger to be logged with</param>
        /// <param name="exception">Exception to be logged</param>
        /// <param name="message">Additional message</param>
        public static void LogErrorResponse(this ILogger logger, Exception exception, string message)
        {
            message = LimitLogText(message, _characterLimitPerObject);
            logger.LogError(exception, message);
        }
        #endregion

        #region Trace Request
        /// <summary>
        /// Logs entering endpoint in 'Enter: {path}' format
        /// </summary>
        /// <param name="logger">Logger instance to be logged with</param>
        /// <param name="path">Endpoint path</param>
        public static void LogTraceRequestEnter(this ILogger logger, string path)
        {
            path = LimitLogText(path, _characterLimitPerPath);
            logger.LogTrace("Enter: {path}", path);
        }

        /// <summary>
        /// Logs exiting endpoint in 'Exit: {path}' format
        /// </summary>
        /// <param name="logger">Logger instance to be logged with</param>
        /// <param name="path">Endpoint path</param>
        public static void LogTraceRequestExit(this ILogger logger, string path)
        {
            path = LimitLogText(path, _characterLimitPerPath);
            logger.LogTrace("Exit: {path}", path);
        }

        #endregion

        #region Private Methods
        private static string LimitLogText(string originalLogText, int limit)
        {
            string retVal = originalLogText;
            if (originalLogText.Length > limit)
                retVal = originalLogText[..limit] + "...";
            return retVal;
        }
        #endregion
    }
}

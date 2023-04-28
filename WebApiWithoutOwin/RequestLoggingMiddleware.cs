using System.Diagnostics;

namespace WebApiWithoutOwin
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                await _next(context);
            }
            finally
            {
                stopwatch.Stop();

                var request = context.Request;
                var response = context.Response;

                var message = string.Format("\r\n{0} {1} {2} - {3}ms", request.Method, request.Path, response.StatusCode, stopwatch.ElapsedMilliseconds);
                File.AppendAllText($"{AppDomain.CurrentDomain.BaseDirectory}customLog.txt", message);
                Console.WriteLine(message);
            }
        }
    }

}
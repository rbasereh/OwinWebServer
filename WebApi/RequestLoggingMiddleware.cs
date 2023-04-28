using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace WebApi
{
    public class RequestLoggingMiddleware : OwinMiddleware
    {
        public RequestLoggingMiddleware(OwinMiddleware next) : base(next) { }

        public override async Task Invoke(IOwinContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                await Next.Invoke(context);
            }
            finally
            {
                stopwatch.Stop();

                var request = context.Request;
                var response = context.Response;

                var message = string.Format("\r\n{0} {1} {2} - {3}ms", request.Method, request.Uri.PathAndQuery, response.StatusCode, stopwatch.ElapsedMilliseconds);
                File.AppendAllText($"{AppDomain.CurrentDomain.BaseDirectory}customLog.txt", message);
                Console.WriteLine(message);
            }
        }
    }
}

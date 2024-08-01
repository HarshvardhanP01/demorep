using Microsoft.AspNetCore.Http;
//using System.IO;
//using System.Text;
using System.Threading.Tasks;

namespace CustomeMiddlewares.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"{nameof(RequestResponseLoggingMiddleware)}-Before next Middleware");
            await _next(context);
            context.Response.WriteAsync("Response Modified by Middleware...");
            Console.WriteLine($"{nameof(RequestResponseLoggingMiddleware)}-After next Middleware");//Actual next and prev functionality.

        }
    }
    public static class RequestResponseLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseReqResLog(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            return app;
        }
    }
}

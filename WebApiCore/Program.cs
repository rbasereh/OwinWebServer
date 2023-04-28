using Owin;
using System.Web.Http;

namespace WebApiCore
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            // Uncomment this to use HTTP.sys
            // builder.WebHost.UseHttpSys();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Routing will win over the OWIN middleware
            app.MapGet("/", () => "Hello World!");

            // Wire up ASP.NET Core controllers
            app.MapControllers();

            // This will run the owin pipeline on top of ASP.NET Core
            app.UseOwinApp(owinApp =>
            {
                HttpConfiguration config = new HttpConfiguration();
                config.Routes.MapHttpRoute(
                    name: "Default",
                    routeTemplate: "{controller}",
                    defaults: new { controller = "Home" }
                );

                config.MapHttpAttributeRoutes();
                owinApp.Use<RequestLoggingMiddleware>();
                owinApp.UseWebApi(config);
            });

            app.Run();
        }
    }
}
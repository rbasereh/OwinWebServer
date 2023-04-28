using Microsoft.Owin.Builder;
using Owin;
using System.Web.Http;

namespace WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "{controller}",
                defaults: new { controller = "Home" }
            );

            config.MapHttpAttributeRoutes();
            builder.Use<RequestLoggingMiddleware>();
            builder.UseWebApi(config);
        }
    }
}
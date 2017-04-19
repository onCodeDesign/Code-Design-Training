using System.Web.Http;
using ConsoleHost.Filters;
using iQuarc.AppBoot.WebApi;
using Owin;

namespace ConsoleHost
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}"
            );

            AppBootBootstrapper.Run().ConfigureWebApi(config);

            config.Filters.Add(new ConsoleLogFilter());

            appBuilder.UseWebApi(config);
        }
    }
}
using System.Web.Http;
using System.Web.Http.Cors;

namespace CompanyAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
            name: "swagger_root",
            routeTemplate: "",
            defaults: null,
            constraints: null,
            handler: new Swashbuckle.Application.RedirectHandler((message => message.RequestUri.ToString()), "swagger"));

            config.Routes.MapHttpRoute(
            name: "ResourceNotFound",
            routeTemplate: "{*uri}",
            defaults: new { controller = "InvalidRoute", uri = RouteParameter.Optional });

            config.EnableCors(new EnableCorsAttribute("*", "*", "GET,PUT,POST,DELETE"));

        }
    }
}

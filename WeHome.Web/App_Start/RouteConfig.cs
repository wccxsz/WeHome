using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WeHome.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();


            routes.MapRoute(
                name: "single",
                url: "single/{*catchall}",
                defaults: new {controller = "Single", action = "Index"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}

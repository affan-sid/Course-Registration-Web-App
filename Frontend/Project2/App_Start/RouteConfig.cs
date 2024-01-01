using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id1}/{id2}",
                defaults: new { controller = "Registration", action = "Index", id1 = UrlParameter.Optional, id2 = UrlParameter.Optional }
            );
        }
    }
}

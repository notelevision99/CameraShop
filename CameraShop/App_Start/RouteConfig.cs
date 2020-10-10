using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CameraShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "chi-tiet-san-pham",
            url: "san-pham/{id}",
            defaults: new { controller = "Home", action = "Details", id = UrlParameter.Optional }
        );

            routes.MapRoute(
              name: "danh-muc-san-pham",
              url: "danh-muc-san-pham/{action}/{id}",
              defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

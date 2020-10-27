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
            name: "about",
            url: "about/{id}",
            defaults: new { controller = "InfoCompany", action = "About", id = UrlParameter.Optional }
        );

            routes.MapRoute(
            name: "chi-tiet-san-pham",
            url: "san-pham/{alias}",
            defaults: new { controller = "Home", action = "Details", id = UrlParameter.Optional }
        );

            routes.MapRoute(
            name: "san-pham",
            url: "san-pham/{id}",
            defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional }
        );

            routes.MapRoute(
              name: "danh-muc-san-pham",
              url: "danh-muc-san-pham/{action}/{Category}",
              defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional }
          );


            routes.MapRoute(
            name: "gio-hang",
            url: "gio-hang",
            defaults: new { controller = "Cart", action = "Cart", id = UrlParameter.Optional }
        );

            routes.MapRoute(
            name: "thanh-toan",
            url: "gio-hang/thanh-toan",
            defaults: new { controller = "Cart", action = "CheckOut", id = UrlParameter.Optional }
        );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

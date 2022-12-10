using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace TWANCOSMETICS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "Product Detail",
              url: "chi-tiet/{name}-{id}",
              defaults: new { controller = "Product", action = "ProductDetail", id = UrlParameter.Optional },
              namespaces: new[] { "TWANCOSMETICS.Controllers" }
            );
           // routes.MapRoute(
           //    name: "ProductCategory",
           //    url: "san-pham/{name}-{id}",
           //    defaults: new { controller = "Index", action = "Product", id = UrlParameter.Optional },
           //    namespaces: new[] { "TWANCOSMETICS.Controllers" }
           //);
            //routes.MapRoute(
            //    name: "ProductCategory",
            //    url: "Product.htm",
            //    defaults: new { controller = "Product", action = "ProductCategory", id = UrlParameter.Optional },
            //    namespaces: new string[] { "TWANCOSMETICS.Web.Controllers" }
            //);
        }
    }
}

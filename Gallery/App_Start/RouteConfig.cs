using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Gallery
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Usuario", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Gallery",
                url: "{controller}/{action}/{userEmail}",
                defaults: new { controller = "Galeria", action = "Index", userEmail = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "Fotos",
<<<<<<< HEAD
                url: "{controller}/{action}/{idGaleria}",
                defaults: new { controller = "Foto", action = "Index", idGaleria = UrlParameter.Optional }
=======
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Foto", action = "Index", id = UrlParameter.Optional }
>>>>>>> 4781a9fe508d85061cceef2919adeeed61477838
                );
        }
    }
}
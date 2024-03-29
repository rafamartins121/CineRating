﻿using System.Web.Mvc;
using System.Web.Routing;

namespace CineRating {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Filmes", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
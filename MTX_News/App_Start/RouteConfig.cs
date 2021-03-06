﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MTX_News
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


        //    routes.MapRoute(
        //    name: "Zapisz",
        //    url: "Komentarz/ZapiszKomentarz",
        //    defaults: new { controller = "Komentarz", action = "ZapiszKomentarz"}
        //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Komentarz", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

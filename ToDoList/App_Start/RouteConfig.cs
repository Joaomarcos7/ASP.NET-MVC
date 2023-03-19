using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ToDoList
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Tarefas", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "AREAS",
               url: "Areas/{action}",
               defaults: new { controller = "Areas", action = "Index", id = UrlParameter.Optional }
           );

        }
    }
}

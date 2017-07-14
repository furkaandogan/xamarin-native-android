﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Odev.Api
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
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { controller = "Ev", action = "GetList", id = RouteParameter.Optional }
            );
        }
    }
}
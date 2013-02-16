﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           // config.Routes.MapHttpRoute(
           //    name: "VoteApi",
           //    routeTemplate: "api/Vote/AddQuestion",
           //    defaults: new
           //    {
           //        controller = "Vote",
           //        action = "AddQuestion"
           //    }
           //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional
                }
            );
        }
    }
}

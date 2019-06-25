using HTTPMethodHandler.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HTTPMethodHandler
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // register Delegating Handlers
            config.MessageHandlers.Add(new MethodDelegatingHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}

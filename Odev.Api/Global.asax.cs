using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Odev.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);
            formatters.Remove(formatters.JsonFormatter);

            Newtonsoft.Json.JsonSerializerSettings serializeSettings = new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore  };
            System.Net.Http.Formatting.JsonMediaTypeFormatter jsonFormatter = new System.Net.Http.Formatting.JsonMediaTypeFormatter() { Indent = false, SerializerSettings = serializeSettings };
            formatters.Add(jsonFormatter);
        } 
    }
}

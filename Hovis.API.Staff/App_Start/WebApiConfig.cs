using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PartialResponse.Net.Http.Formatting;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Hovis.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            ConfigureJsonSerialization(config);

            ConfigureCors(config);
        }

        private static void ConfigureJsonSerialization(HttpConfiguration config)
        {
            GlobalConfiguration.Configuration.Formatters.Clear();

            //This uses partial response to allow us to specify fields to return
            //for example ?fields=firstName would only return json with firstName specified (using ADUsers as an example)
            //https://www.nuget.org/packages/WebApi.PartialResponse/
            //https://github.com/dotarj/PartialResponse
            GlobalConfiguration.Configuration.Formatters.Add(new PartialJsonMediaTypeFormatter { IgnoreCase = true });

            var json = GlobalConfiguration.Configuration.Formatters.FirstOrDefault() as PartialJsonMediaTypeFormatter;

            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            //camel case our response
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private static void ConfigureCors(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*"); //todo: perhaps restrict the origin
            config.EnableCors(cors);
        }
    }
}
using Bro2Bro.WebAPI.Handler;

using System.Web.Http;

namespace Bro2Bro.WebAPI {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            config.MessageHandlers.Add(new TokenHandler());
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
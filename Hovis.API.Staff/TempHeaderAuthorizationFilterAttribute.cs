using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Hovis.Api
{
    public class TempHeaderAuthorizationFilterAttribute : AuthorizationFilterAttribute
    {
        private const string key = "RYl1K0A60b1wAK4wUK4vOwo5D7PFHN07wtmNFLAy";

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Authorization;

            var qs = actionContext.Request.GetQueryNameValuePairs()
                .SingleOrDefault(x => x.Key.Equals("apikey"))
                .Value;

            //verified by api key in qs
            if (qs != null && qs.Equals(key))
                return;

            if (authHeader == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized");
                return;
            }

            if (authHeader.Scheme != key)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized");
                return;
            }

            base.OnAuthorization(actionContext);
        }
    }
}
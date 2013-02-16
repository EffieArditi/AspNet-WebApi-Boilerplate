using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace WebApi.API.FilterAttributes
{
    public class ApiAuthenticationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            IEnumerable<string> authHeaderValues;
            if (actionContext.Request.Headers.TryGetValues("Api-AuthKey", out authHeaderValues))
            {
                string headerValue = authHeaderValues.First();
                if (headerValue == "myAccessToken")
                {
                    return;
                }

                HandleUnauthorizedRequest(actionContext);
            }

            HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Authentication Failed.");
        }
    }
}
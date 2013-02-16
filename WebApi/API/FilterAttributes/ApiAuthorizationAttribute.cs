using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using WebApi.Model;
using StructureMap;
using WebApi.Common;
using WebApi.Repository;

namespace WebApi.API.FilterAttributes
{
    public static class InMemoryAuthorizationTable
    {
        public static UserRole GetRoleForUser(User user)
        {
            if (user.Name.ToLower() == "effie")
            {
                return UserRole.Admin;
            }

            return UserRole.Guest;
        }
    }

    public class ApiAuthorizationAttribute : AuthorizeAttribute
    {
        public UserRole[] UserRoles { get; set; }

        public ApiAuthorizationAttribute(params UserRole[]  userRoles)
        {
            UserRoles = userRoles;
        }

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            IEnumerable<string> authHeaderValues;
            if (actionContext.Request.Headers.TryGetValues("Api-UserId", out authHeaderValues))
            {
                string headerValue = authHeaderValues.First();
                User user = ObjectFactory.GetInstance<IUserRepository>().GetById(headerValue);
                if (user == null)
                {
                    HandleUnauthorizedRequest(actionContext);
                    return;
                }
                UserRole role = InMemoryAuthorizationTable.GetRoleForUser(user);
                if (UserRoles.Contains(role))
                {
                    return;
                }

                HandleUnauthorizedRequest(actionContext);
            }

            HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "User is not authorized for action.");
        }
    }
}
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace WebApi.API.FilterAttributes
{
    public class ApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            // Exception type to status code mapping
            Type exceptionType = actionExecutedContext.Exception.GetType();
            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                statusCode = HttpStatusCode.Unauthorized;
            }

            actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(statusCode, 
                                                                                    actionExecutedContext.Exception.Message);
        }
    }
}
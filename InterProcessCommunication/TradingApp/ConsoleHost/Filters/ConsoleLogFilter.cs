using System;
using System.Net;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ConsoleHost.Filters
{
    class ConsoleLogFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fffff}:");
            Console.WriteLine($"  - {actionContext.Request.Method.Method}: {actionContext.Request.RequestUri.Scheme}://{actionContext.Request.RequestUri.Authority}{actionContext.Request.RequestUri.AbsolutePath}");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            HttpStatusCode status = actionExecutedContext.Response.StatusCode;
            Console.WriteLine($"\t - Status: {(int)status} - {status} Reason: {actionExecutedContext.Response?.ReasonPhrase}\n");
        }
    }
}
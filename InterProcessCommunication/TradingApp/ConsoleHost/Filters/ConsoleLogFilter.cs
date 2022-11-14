using System;
using System.Collections.Generic;
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

            string remote = GetRemote(actionContext);
            Console.WriteLine($"\t - Remote: {remote}");
        }

        private static string GetRemote(HttpActionContext actionContext)
        {
            string toReturn = string.Empty;

            IEnumerable<string> values;
            if (actionContext.Request.Headers.TryGetValues("Postman-Token", out values))
                toReturn = $"Postman-Token: {string.Join("; ", values)}";

            if (actionContext.Request.Headers.TryGetValues("Service-Proxy", out values))
                toReturn = $"Service-Proxy: {string.Join("; ", values)}";

            return toReturn;
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
            {
                HttpStatusCode status = actionExecutedContext.Response.StatusCode;
                Console.WriteLine($"\t - Status: {(int) status} - {status} Reason: {actionExecutedContext.Response?.ReasonPhrase}\n");
            }
            else if (actionExecutedContext.Exception != null)
            {
                Console.WriteLine($"\t  Error: {actionExecutedContext.Exception.Message}");
            }
            else
            {
                Console.WriteLine("\t Unknown call status");
            }
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TemplateApplication.API.Middlewares
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await GlobalHandleExceptionAsync(context, ex);
            }
        }

        private static Task GlobalHandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var json = new
            {
                context.Response.StatusCode,
                TraceId = context.TraceIdentifier,
                Message = exception.Message,
                InnerException = exception.InnerException,
                Source = exception.Source,
                StackTrace = exception.StackTrace,
                DateTime = DateTime.Now.ToString("dd/mm/yyyy hh24:mi:ss")
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
        }
    }
}

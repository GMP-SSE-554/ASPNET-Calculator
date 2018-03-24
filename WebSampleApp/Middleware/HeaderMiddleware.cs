using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSampleApp
{
    public class HeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public HeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("sampleheader",
                new string[] { "addheadermiddleware" });
            return _next(httpContext);
        }
    }

    public static class HeaderMiddleWareExtensions
    {
        public static IApplicationBuilder UseHeaderMiddleware(
            this IApplicationBuilder builder) =>
                builder.UseMiddleware<HeaderMiddleware>();
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSampleApp
{
    public class Heading1Middleware
    {
        private readonly RequestDelegate _next;

        public Heading1Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("<h1>From Middleware</h1>");
            await _next(httpContext);
        }
    }

    public static class Heading1MiddleWareExtensions
    {
        public static IApplicationBuilder UseHeading1Middleware(
            this IApplicationBuilder builder) =>
                builder.UseMiddleware<Heading1Middleware>();
    }
}

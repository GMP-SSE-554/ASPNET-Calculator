using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSampleApp
{
    public class RequestAndResponseSample
    {
        public static string GetDiv(string key, string value) =>
            $"<div><span>{key}:</span> <span>{value}</span></div>";

        public static string GetRequestInformation(Microsoft.AspNetCore.Http.HttpRequest request)
        {
            var sb = new System.Text.StringBuilder();
            sb.Append(GetDiv("scheme", request.Scheme));
            sb.Append(GetDiv("host", request.Host.HasValue ? request.Host.Value : "no host"));
            sb.Append(GetDiv("path", request.Path));
            sb.Append(GetDiv("query string", request.QueryString.HasValue ? request.QueryString.Value : "no query string"));

            sb.Append(GetDiv("method", request.Method));
            sb.Append(GetDiv("protocol", request.Protocol));

            return sb.ToString();
        }
    }
}

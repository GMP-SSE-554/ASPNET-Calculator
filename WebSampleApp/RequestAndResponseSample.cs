using Microsoft.AspNetCore.Http;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace WebSampleApp
{
    public class RequestAndResponseSample
    {
        public static string GetForm(HttpRequest request)
        {
            string result = string.Empty;
            switch (request.Method)
            {
                case "GET":
                    result = GetForm(0, 0, 0);
                    break;
                case "POST":
                    result = ShowForm(request);
                    break;
                default:
                    break;
            }

            return result;
        }

        private static string GetForm(int x, int y, int result) =>
            "<form method=\"post\" action=\"form\">" +
            $"X: <input type=\"text\" name=\"x\" value = {x} /> <br>" +
            $"Y: <input type=\"text\" name=\"y\" value = {y} /> <br>" +
            "Operation: <input type=\"radio\" name=\"operation\" value=\"Add\" checked> Add " +
            "<input type=\"radio\" name=\"operation\" value=\"Subtract\" > Subtract " +
            "<input type=\"radio\" name=\"operation\" value=\"Multiply\" > Multiply " +
            "<input type=\"radio\" name=\"operation\" value=\"Divide\" > Divide <br>" +
            $"Result: {result} <br>" +
            "<input type=\"submit\" value=\"Submit\" />" +
        "</form>";

        private static string ShowForm(HttpRequest request)
        {
            if (request.HasFormContentType)
            {
                IFormCollection coll = request.Form;
                int result = 0;

                int x = int.Parse(coll["x"]);
                int y = int.Parse(coll["y"]);

                switch (coll["operation"])
                {
                    case "Add":
                        result = x + y;
                        break;
                    case "Subtract":
                        result = x - y;
                        break;
                    case "Multiply":
                        result = x * y;
                        break;
                    case "Divide":
                        result = x / y;
                        break;
                    default:
                        break;
                }

                return GetForm(x, y, result);
            }
            else return "no form".Div();
        }
    }
}

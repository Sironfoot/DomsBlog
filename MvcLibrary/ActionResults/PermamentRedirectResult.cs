using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;

namespace MvcLibrary.ActionResults
{
    public class PermamentRedirectResult : ActionResult
    {
        public PermamentRedirectResult(string url)
        {
            this.Url = url;
        }

        public string Url { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;

            response.Status = "301 Moved Permanently";
            response.StatusCode = 301;
            response.AddHeader("Location", Url);
            response.End();
        }
    }
}
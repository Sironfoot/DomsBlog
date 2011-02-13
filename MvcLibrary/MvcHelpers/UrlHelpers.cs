using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;

namespace MvcLibrary.MvcHelpers
{
    public static class UrlHelpers
    {
        public static string ActionWithQueryStrings(this UrlHelper helper, string action, object queryStringValues)
        {
            string url = helper.Action(action, queryStringValues);

            if (!url.Contains('?'))
            {
                url += "?";
            }
            else
            {
                url += "&amp;";
            }

            HttpRequestBase request = helper.RequestContext.HttpContext.Request;

            foreach (string key in request.QueryString.Keys)
            {
                url += key + "=" + request.QueryString[key] + "&amp;";
            }

            return url;
        }

        public static string CurrentUrlWithQueryStrings(this UrlHelper helper, object queryStringValues)
        {
            string action = helper.RequestContext.RouteData.Values["action"].ToString();

            return helper.ActionWithQueryStrings(action, queryStringValues);
        }
    }
}
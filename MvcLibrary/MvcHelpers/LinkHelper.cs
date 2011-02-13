using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web;

namespace MvcLibrary.MvcHelpers
{
    public static class LinkHelper
    {
        public static string SelectedActionLinkListItem(this HtmlHelper helper, string linkText, string actionName,
            string controllerName)
        {
            string currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
            string currentActionName = (string)helper.ViewContext.RouteData.Values["action"];

            var builder = new TagBuilder("li");

            // Add selected class
            if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) &&
                currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
            {
                builder.AddCssClass("Selected");
            }

            // Add link
            builder.InnerHtml = helper.ActionLink(linkText, actionName, controllerName).ToString();

            // Render Tag Builder
            return builder.ToString(TagRenderMode.Normal);
        }

        public static bool IsControllerSelected(this HtmlHelper helper,string controllerName)
        {
            string currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];

            if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }

        public static string CurrentUrlWithQueryStrings(this HtmlHelper helper, object queryStringValues)
        {
            HttpRequestBase request = helper.ViewContext.RequestContext.HttpContext.Request;

            string fullUrl = request.Url.ToString();

            int indexOfQuestion = fullUrl.IndexOf('?');
            if (indexOfQuestion != -1)
            {
                fullUrl = fullUrl.Substring(0, indexOfQuestion);
            }

            

            return fullUrl;
        }
    }
}
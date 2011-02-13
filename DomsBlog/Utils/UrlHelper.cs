using System.Web.Configuration;
using System.Web.Mvc;

namespace DomsBlog.Utils
{
    public static class UrlBuilder
    {
        public static string ResourceFolder(this UrlHelper helper)
        {
            string timestamp = WebConfigurationManager.AppSettings["ResourceFolderTimeStamp"];
            return helper.Content("~/Content-" + timestamp);
        }

        public static string ParseAmpersands(this string url)
        {
            return (url ?? "").Replace("&", "&amp;");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DomsBlog.Utils
{
    public class BlogValues
    {
        public static string CaptchaPublicKey()
        {
            return WebConfigurationManager.AppSettings["CaptchaPublicKey"];
        }

        public static string CaptchaPrivateKey()
        {
            return WebConfigurationManager.AppSettings["CaptchaPrivateKey"];
        }
    }
}

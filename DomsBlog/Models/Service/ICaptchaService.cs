using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Models.Service
{
    public interface ICaptchaService
    {
        bool PassesCaptcha(HttpRequestBase request, string key);
    }
}
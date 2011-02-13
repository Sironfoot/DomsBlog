using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO;

namespace DomsBlog.Models.Service
{
    public class ReCaptchaService : ICaptchaService
    {
        public bool PassesCaptcha(HttpRequestBase request, string key)
        {
            string challengeField = request.Form["recaptcha_challenge_field"];
            string responseField = request.Form["recaptcha_response_field"];

            string data = "privatekey=" + key + "&remoteip=" + request.UserHostAddress +
                "&challenge=" + challengeField + "&response=" + responseField;

            HttpWebRequest captchaRequest = (HttpWebRequest)WebRequest.Create("http://api-verify.recaptcha.net/verify");
            captchaRequest.Method = "POST";
            captchaRequest.ContentType = "application/x-www-form-urlencoded";

            byte[] buffer = Encoding.ASCII.GetBytes(data);

            captchaRequest.ContentLength = buffer.Length;

            Stream postData = captchaRequest.GetRequestStream();
            postData.Write(buffer, 0, buffer.Length);
            postData.Close();

            HttpWebResponse captchaResponse = (HttpWebResponse)captchaRequest.GetResponse();
            StreamReader reader = new StreamReader(captchaResponse.GetResponseStream());
            string returnData = reader.ReadToEnd();

            string booleanString = returnData.Split('\n')[0];
            bool passCaptcha = Boolean.TryParse(booleanString, out passCaptcha) ? passCaptcha : false;

            return passCaptcha;
        }
    }
}
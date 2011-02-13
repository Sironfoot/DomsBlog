using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MvcLibrary.Extensions;
using System.Net.Mail;
using DomsBlog.Models.Service;
using DomsBlog.Utils;

namespace DomsBlog.Controllers
{
    public class EgoController : MasterController
    {
        private ISitemapService SitemapService = null;

        public EgoController()
        {
            SitemapService = new SitemapService();
        }

        //
        // GET: /Ego/

        public ActionResult Index()
        {
            long ticksDob = new DateTime(1981, 7, 15).Ticks;
            long ticksNow = DateTime.Now.Ticks;
            TimeSpan span = new TimeSpan(ticksNow - ticksDob);

            int age = (int)Math.Floor(span.TotalDays / 365.25);

            ViewData["age"] = age;

            return View();
        }

        public ActionResult CV()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contact(string name, string email, string message)
        {
            ICaptchaService captchaService = new ReCaptchaService();
            if (!captchaService.PassesCaptcha(Request, BlogValues.CaptchaPrivateKey()))
            {
                ModelState.AddModelError("Captcha", "Failed Captcha test, please try again.");
            }
            if (name.IsNullEmptyOrWhitespace())
            {
                ModelState.AddModelError("name", "Required.");
            }
            if (email.IsNullEmptyOrWhitespace())
            {
                ModelState.AddModelError("email", "Required.");
            }
            if (!email.IsEmailAddress())
            {
                ModelState.AddModelError("email", "Not a valid email address.");
            }
            if (message.IsNullEmptyOrWhitespace())
            {
                ModelState.AddModelError("message", "Required.");
            }

            if (ModelState.IsValid)
            {
                MailAddress from = new MailAddress(email, name);
                MailAddress to = new MailAddress("sironfoot@msn.com");

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = from;
                mailMessage.To.Add(to);
                mailMessage.Subject = "Message From Contact Form (DominicPettifer.co.uk)";
                mailMessage.Body = "Message sent from Contact form at DominicPettifer.co.uk...\n\n\"" +
                                    message + "\"\n\n" +
                                   "Name:  " + name + "\n" +
                                   "Email: " + email;
                mailMessage.IsBodyHtml = false;

                SmtpClient client = new SmtpClient();
                client.Send(mailMessage);

                return RedirectToAction("Contact", new { success = "true" });
            }
            else
            {
                return View();
            }
        }

        public ActionResult Sitemap()
        {
            return View(SitemapService.GetSitemapForPage());
        }

        public ActionResult Legal()
        {
            return View();
        }
    }
}
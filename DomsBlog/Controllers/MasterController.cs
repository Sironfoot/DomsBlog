using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DomsBlog.Models.Service;
using DomsBlog.Models.ViewModels;

namespace DomsBlog.Controllers
{
    public abstract class MasterController : Controller
    {
        protected IPollService PollService = null;
        protected IImageService ImageService = null;

        public MasterController()
        {
            ImageService = new ImageService();
            PollService = new PollService();
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            ViewData["RandomImage"] = ImageService.GetRandomImage();
            ViewData["TwitterFeed"] = TwitterService.GetService().GetTwitterFeed("Sironfoot", 5);
            ViewData["LatestPoll"] = PollService.GetLatestPoll(HttpContext.Request);

            base.OnResultExecuting(filterContext);
        }
    }
}
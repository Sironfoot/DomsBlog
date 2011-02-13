using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DomsBlog.Models.Service;
using MvcLibrary.ActionResults;

namespace DomsBlog.Controllers
{
    public class RssController : Controller
    {
        //
        // GET: /Rss/

        private IBlogService BlogService = null;

        public RssController()
        {
            BlogService = new BlogService(HttpContext);
        }

        public ActionResult LatestBlogs()
        {
            RssFeed feed = BlogService.GetRssBlogFeed(20, "http://www.dominicpettifer.co.uk", "http://www.dominicpettifer.co.uk/Blog/{0}/{1}");
            return new RssResult(feed);
        }
    }
}
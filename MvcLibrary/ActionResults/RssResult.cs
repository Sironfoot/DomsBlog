using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Web;

namespace MvcLibrary.ActionResults
{
    public class RssResult : ActionResult
    {
        public RssResult(RssFeed feed)
        {
            if(feed == null)
            {
                throw new ArgumentNullException("feed");
            }

            this.Feed = feed;
        }

        public RssFeed Feed { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = "application/rss+xml";
            response.Write(Feed.ToXmlDocument().ToString(SaveOptions.None));
        }
    }
}
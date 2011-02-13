using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.MvcHelpers;
using MvcLibrary.UrlTools;

namespace DomsBlog.Models.ViewModels
{
    public class SitemapView : BaseView
    {
        public SitemapView()
        {
            Blogs = new List<Blog>();
            Polls = new List<Poll>();
        }

        public IList<Blog> Blogs { get; set; }
        public IList<Poll> Polls { get; set; }

        public class Blog
        {
            public Blog(int id, string title, bool hasImages)
            {
                this.Id = id;
                this.Title = title;
                this.HasImages = hasImages;

                this.Url = "/Blog/" + id + "/" + title.ToFriendlyUrl();
            }

            public int Id { get; private set; }
            public string Title { get; private set; }
            public string Url { get; private set; }

            public bool HasImages { get; private set; }
        }

        public class Poll
        {
            public Poll(int id, string title)
            {
                this.Id = id;
                this.Title = title;

                this.Url = "/Poll/" + id + "/" + title.ToFriendlyUrl();
            }

            public int Id { get; private set; }
            public string Title { get; private set; }
            public string Url { get; private set; }
        }
    }
}
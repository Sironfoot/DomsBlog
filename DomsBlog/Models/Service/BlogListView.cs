using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.UrlTools;

namespace DomsBlog.Models.Service
{
    public class BlogListView
    {
        public BlogListView(int id, string title, string blogType, string abstractText,
            DateTime postedDate, long numImages, long numComments, IList<string> tags)
        {
            this.BlogId = id;
            this.Title = title;
            this.BlogType = blogType;
            this.Abstract = abstractText;
            this.PostedDate = postedDate;
            this.NumImages = numImages;
            this.NumComments = numComments;
            this.Tags = tags;
        }

        public int BlogId { get; private set; }
        public string Title { get; private set; }
        public string BlogType { get; private set; }
        public string Abstract { get; private set; }
        public DateTime PostedDate { get; private set; }

        public long NumImages { get; private set; }
        public long NumComments { get; private set; }

        public IList<string> Tags { get; private set; }
    }
}
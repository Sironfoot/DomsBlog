using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.Extensions;
using MvcLibrary.UrlTools;
using DomsBlog.Models.NHibernate.Domain;

namespace DomsBlog.Models.ViewModels
{
    public class BlogImagesView : BaseView
    {
        public BlogImagesView(int blogId, string shortTitle, string title, DateTime postedDate,
            string blogType, string abstractText, int numImages, int numComments)
        {
            this.BlogId = blogId;
            this.ShortTitle = shortTitle;
            this.Title = title;
            this.UrlFriendlyTitle = title.ToFriendlyUrl();
            this.PostedDate = postedDate;
            this.BlogType = blogType;
            this.Abstract = abstractText;
            this.NumImages = numImages;
            this.NumComments = numComments;

            BlogImages = new List<ImageView>();
        }

        public int BlogId { get; private set; }
        public string ShortTitle { get; private set; }
        public string Title { get; private set; }
        public string UrlFriendlyTitle { get; private set; }
        public DateTime PostedDate { get; private set; }
        public string BlogType { get; private set; }
        public string Abstract { get; private set; }

        public int NumImages { get; private set; }
        public int NumComments { get; private set; }

        public IList<ImageView> BlogImages { get; private set; }
    }
}
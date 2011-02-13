using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.Extensions;
using MvcLibrary.UrlTools;

namespace DomsBlog.Models.ViewModels
{
    public class RandomImageView
    {
        public RandomImageView(int id, string altText, string caption, string fileName, int blogId, string blogTitle)
        {
            this.Id = id;
            this.Caption = caption;
            this.AltText = altText.IsNullEmptyOrWhitespace() ? caption : altText;

            this.LargeImageUrl = "/Images/" + id + "/" + fileName;
            this.ThumbnailUrl = "/Images/" + id + "/thumb_" + fileName;

            this.BlogId = blogId;
            this.BlogTitle = blogTitle;
            this.BlogUrlFriendlyTitle = blogTitle.ToFriendlyUrl();
        }

        public int Id { get; private set; }
        public string AltText { get; private set; }
        public string Caption { get; private set; }

        public string LargeImageUrl { get; private set; }
        public string ThumbnailUrl { get; private set; }

        public string BlogTitle { get; set; }
        public string BlogUrlFriendlyTitle { get; set; }
        public int BlogId { get; set; }
    }
}
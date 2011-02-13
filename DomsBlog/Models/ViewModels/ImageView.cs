using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.Extensions;

namespace DomsBlog.Models.ViewModels
{
    public class ImageView
    {
        public ImageView(int id, string altText, string caption, string fileName)
        {
            this.Id = id;
            this.Caption = caption;
            this.AltText = altText.IsNullEmptyOrWhitespace() ? caption : altText;

            this.LargeImageUrl = "/Images/" + id + "/" + fileName;
            this.ThumbnailUrl = "/Images/" + id + "/thumb_" + fileName;
        }

        public int Id { get; private set; }
        public string AltText { get; private set; }
        public string Caption { get; private set; }

        public string LargeImageUrl { get; private set; }
        public string ThumbnailUrl { get; private set; }
    }
}
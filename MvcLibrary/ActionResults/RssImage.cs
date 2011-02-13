using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcLibrary.Extensions;
using System.Xml.Linq;

namespace MvcLibrary.ActionResults
{
    public class RssImage
    {
        public RssImage(string url, string title, string link)
        {
            this.Url = url;
            this.Title = title;
            this.Link = link;
        }

        public string Url { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }

        public string Description { get; set; }

        private int _width = 88;
        public int Width
        {
            get { return _width; }
            set { _width = value.BullyIntoRange(0, 144); }
        }

        private int _height = 31;
        public int Height
        {
            get { return _height; }
            set { _height = value.BullyIntoRange(0, 400); }
        }

        public XElement ToXmlNode()
        {
            return new XElement("image",
                new XElement("url", Url),
                new XElement("title", Title),
                new XElement("link", Link),
                !Description.IsNullEmptyOrWhitespace() ? new XElement("description", Description) : null,
                new XElement("width", Width),
                new XElement("height", Height));
        }
    }
}

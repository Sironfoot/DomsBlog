using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MvcLibrary.Extensions;

namespace MvcLibrary.ActionResults
{
    public class RssFeed
    {
        public RssFeed(string title, string description, string link, IList<RssItem> items)
        {
            this.Title = title;
            this.Description = description;
            this.Link = link;
            this.Items = items;
        }

        public IList<RssItem> Items { get; private set; }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Link { get; private set; }

        public string Category { get; set; }
        public string Copyright { get; set; }
        public RssImage Image { get; set; }

        public XDocument ToXmlDocument()
        {
            return new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("rss",
                    new XAttribute("version", "2.0"),
                    new XElement("channel",
                        new XElement("title", Title),
                        new XElement("link", Link),
                        new XElement("description", Description),
                        !Category.IsNullEmptyOrWhitespace() ? new XElement("category", Category) : null,
                        !Copyright.IsNullEmptyOrWhitespace() ? new XElement("copyright", Copyright) : null,
                         Image != null ? Image.ToXmlNode() : null,
                        Items.Select(i => i.ToXmlNode()).ToArray()
                    )
                )
            );
        }
    }
}
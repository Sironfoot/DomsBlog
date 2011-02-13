using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MvcLibrary.Extensions;

namespace MvcLibrary.ActionResults
{
    public class RssItem
    {
        public RssItem(string title, string link, string description)
        {
            this.Title = title;
            this.Link = link;
            this.Description = description;
        }

        public string Title { get; private set; }
        public string Link { get; private set; }
        public string Description { get; private set; }

        public string Author { get; set; }
        public string Comments { get; set; }
        public string Category { get; set; }
        public DateTime? PudDate { get; set; }
        public RssEnclosure Enclosure { get; set; }

        public XElement ToXmlNode()
        {
            return new XElement("item",
                new XElement("title", Title),
                new XElement("link", Link),
                new XElement("description", Description),
                !Author.IsNullEmptyOrWhitespace() ? new XElement("author", Author) : null,
                !Comments.IsNullEmptyOrWhitespace() ? new XElement("comments", Comments) : null,
                !Category.IsNullEmptyOrWhitespace() ? new XElement("category", Category) : null,
                 PudDate != null ? new XElement("pudDate", PudDate.Value.ToRFC822DateString()) : null, // TODO: Fix typo (pudDate -> pubDate)
                 Enclosure != null ? Enclosure.ToXmlNode() : null);
        }
    }
}
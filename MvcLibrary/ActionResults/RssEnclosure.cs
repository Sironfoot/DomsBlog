using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MvcLibrary.ActionResults
{
    public class RssEnclosure
    {
        public RssEnclosure(string url, long length, string type)
        {
            this.Url = url;
            this.Length = length;
            this.Type = type;
        }

        public string Url { get; private set; }
        public long Length { get; private set; }
        public string Type { get; private set; }

        public XElement ToXmlNode()
        {
            return new XElement("enclosure",
                new XAttribute("url", Url),
                new XAttribute("length", Length),
                new XAttribute("type", Type));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.Extensions;

namespace DomsBlog.Models.Service
{
    public class TwitterFeed
    {
        public TwitterFeed(string username, int maxRecords)
        {
            this.Username = username;
            this.MaxRecords = maxRecords.BullyIntoRange(1, Int32.MaxValue);
            Tweets = new List<Tweet>(this.MaxRecords);
        }

        public string Username { get; private set; }
        public int MaxRecords { get; private set; }

        public IList<Tweet> Tweets { get; set; }

        public Exception Exception { get; set; }
    }
}
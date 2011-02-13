using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Globalization;
using System.Timers;

namespace DomsBlog.Models.Service
{
    public class TwitterService : ITwitterService
    {
        private static object _syncObject = new object();
        private static TwitterService _serviceInstance = null;

        public static TwitterService GetService()
        {
            if (_serviceInstance == null)
            {
                lock (_syncObject)
                {
                    if (_serviceInstance == null)
                    {
                        _serviceInstance = new TwitterService();
                    }
                }
            }

            return _serviceInstance;
        }

        private Dictionary<string, TwitterFeed> Tweets = new Dictionary<string, TwitterFeed>();
        private Timer Timer = null;

        private TwitterService()
        {
            this.Timer = new Timer((1000.0 * 60.0) * 2.0);
            this.Timer.AutoReset = true;
            this.Timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            this.Timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (KeyValuePair<string, TwitterFeed> tweetList in Tweets)
            {
                try
                {
                    List<Tweet> tweets = GetTweets(tweetList.Value.Username, tweetList.Value.MaxRecords);

                    lock (tweetList.Value.Tweets)
                    {
                        tweetList.Value.Tweets = tweets;
                    }

                    tweetList.Value.Exception = null;
                }
                catch (Exception err)
                {
                    tweetList.Value.Exception = err;
                }
            }
        }

        public TwitterFeed GetTwitterFeed(string userName, int maxRecords)
        {
            string key = userName + "_" + maxRecords;

            if (!Tweets.ContainsKey(key))
            {
                lock (this)
                {
                    if (!Tweets.ContainsKey(key))
                    {
                        TwitterFeed feed = new TwitterFeed(userName, maxRecords);

                        try
                        {
                            feed.Tweets = GetTweets(userName, maxRecords);
                            feed.Exception = null;
                        }
                        catch (Exception err)
                        {
                            feed.Exception = err;
                        }

                        Tweets.Add(key, feed);
                    }
                }
            }

            return Tweets[key];
        }

        private List<Tweet> GetTweets(string userName, int maxRecords)
        {
            List<Tweet> tweets = new List<Tweet>();

            WebClient client = new WebClient();
            string xmlData = client.DownloadString("http://twitter.com/statuses/user_timeline/" + userName + ".xml?count=" + maxRecords);

            XDocument doc = XDocument.Parse(xmlData);

            foreach (XElement status in doc.Elements("statuses").Elements("status"))
            {
                string nonRetardedDateTime = Regex.Replace(status.Element("created_at").Value,
                    @"([a-z]{3}) ([a-z]{3}) ([0-9]{2}) ([0-9]{2}:[0-9]{2}:[0-9]{2}) (\+[0-9]{4}) ([0-9]{4})",
                    "$3-$2-$6 $4",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline);

                string text = HttpUtility.HtmlEncode(status.Element("text").Value);
                string clientData = status.Element("source").Value.Trim();

                string clientName = Regex.Replace(clientData, @"<a(.*?)href=""(.*?)"">(.*?)</a>", "$3",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline);
                string clientUrl = Regex.Replace(clientData, @"<a(.*?)href=""(.*?)"">(.*?)</a>", "$2",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline);

                Tweet tweet = new Tweet();

                DateTime postedDateUtc = DateTime.Parse(nonRetardedDateTime);
                tweet.PostedDate = postedDateUtc.IsDaylightSavingTime() ? postedDateUtc.AddHours(1) : postedDateUtc;

                //http://weblogs.asp.net/farazshahkhan/archive/2008/08/09/regex-to-find-url-within-text-and-make-them-as-link.aspx
                tweet.Text = Regex.Replace(text, @"(http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&amp;\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?)", "<a href=\"$1\">$1</a>", RegexOptions.IgnoreCase);

                tweet.Text = Regex.Replace(tweet.Text, @"@([a-z0-9\\_\\-]+)", "@<a href=\"http://twitter.com/$1\">$1</a>", RegexOptions.IgnoreCase);

                tweet.ClientName = clientName;
                tweet.ClientUrl = clientUrl.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase) ? clientUrl : "http://twitter.com";

                tweets.Add(tweet);
            }

            return tweets;
        }
    }
}
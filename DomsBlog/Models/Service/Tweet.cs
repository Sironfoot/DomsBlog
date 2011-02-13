using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.Extensions;

namespace DomsBlog.Models.Service
{
    public class Tweet
    {
        public string Text { get; set; }
        public DateTime PostedDate { get; set; }
        public string ClientName { get; set; }
        public string ClientUrl { get; set; }

        public string DisplayFriendlyPostedDate
        {
            get
            {
                DateTime date = DateTime.Now;

                // Difference between current time with Tweet time in minutes
                double minutesDiff = ((double)(date.Ticks - PostedDate.Ticks) / 10000.0) / 1000.0 / 60.0;

                if (minutesDiff < 1.0)
                {
                    return "less than 1 minute ago";
                }
                else
                {
                    if (minutesDiff < 60.0)
                    {
                        // Round down to n minutes so difference of 3mins 59sec returns "3 minutes ago"
                        int minutes = (int)Math.Floor(minutesDiff);
                        return minutes + " minute" + (minutes > 1 ? "s" : "") + " ago";
                    }
                    else
                    {
                        double hoursDiff = minutesDiff / 60.0;

                        if ((hoursDiff + 0.5) < 24.0)
                        {
                            // Twiter rounds UP to nearest hour if it's next hour is less than 30 minutes away
                            // So difference of 2hrs 29min returns "about 2 hours ago" whereas difference
                            // of 2hrs 31mins returns "about 3 hours ago"
                            int hours = (int)Math.Floor(hoursDiff + 0.5);
                            return "about " + hours + " hour" + (hours > 1 ? "s" : "") + " ago";
                        }
                        else
                        {
                            // More than 24 hours so return an actual Date
                            return PostedDate.ToStringWithOrdinal("h:mm tt MMMM d");
                        }
                    }
                }
            }
        }
    }
}
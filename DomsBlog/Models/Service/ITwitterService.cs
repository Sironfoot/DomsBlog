using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Models.Service
{
    public interface ITwitterService
    {
        TwitterFeed GetTwitterFeed(string userName, int maxRecords);
    }
}
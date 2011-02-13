using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.Extensions;

namespace DomsBlog.Models.DataModels
{
    public class BlogPageSimpleData
    {
        public BlogPageSimpleData(int pageNumber, string pageName)
        {
            this.PageName = pageName;
            this.PageNumber = pageNumber.BullyIntoRange(1, Int32.MaxValue);
        }

        public int PageNumber { get; private set; }
        public string PageName { get; private set; }
    }
}
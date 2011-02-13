using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomsBlog.Models.ViewModels;

namespace DomsBlog.Models.Service
{
    interface ISitemapService
    {
        SitemapView GetSitemapForPage();
    }
}

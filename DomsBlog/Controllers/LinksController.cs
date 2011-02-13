using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace DomsBlog.Controllers
{
    public class LinksController : MasterController
    {
        //
        // GET: /Links/

        public ActionResult Index()
        {
            return View();
        }

    }
}
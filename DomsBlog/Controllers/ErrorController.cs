using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace DomsBlog.Controllers
{
    public class ErrorController : MasterController
    {
        //
        // GET: /Error/

        public ActionResult Process(int code)
        {
            switch (code)
            {
                case 404:
                    Response.StatusCode = 404;
                    return View("404");
            }

            return View("404");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace DomsBlog.Controllers
{
    public class PortfolioController : MasterController
    {
        //
        // GET: /Portfolio/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(string name)
        {
            switch (name)
            {
                case "Dominics-Blog":
                    return View("DominicsBlog");
                case "Borders-Health-In-Hand":
                    return View("BordersHealthInHand");
                case "Private-Menorca":
                    return View("PrivateMenorca");
                case "SCRI-Seed-Archive-System":
                    return View("SeedArchiveSystem");
                case "Blue-Island-Sun":
                    return View("BlueIslandSun");
            }

            return View("404");
        }
    }
}
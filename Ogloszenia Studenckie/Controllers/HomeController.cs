using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ogloszenia_Studenckie.Controllers
{
    public class HomeController : Controller
    {
        private Aplikacje_InternetoweEntities1 db = new Aplikacje_InternetoweEntities1();
        public ActionResult Index()
        {
            var ogloszenie = (from a in db.Ogloszenie
                             select a).Take(20);
            return View(ogloszenie);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
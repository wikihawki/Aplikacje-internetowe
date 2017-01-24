using Ogloszenia_Studenckie.DAL;
using Ogloszenia_Studenckie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ogloszenia_Studenckie.Controllers
{
    [CheckAuthorization]
    public class ManageController : Controller
    {
        private Aplikacje_InternetoweEntities1 db = new Aplikacje_InternetoweEntities1();
        // GET: Manage
        public ActionResult Index()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null) 
            {
                var userIdClaim = claimsIdentity.Claims.FirstOrDefault(X => X.Type == ClaimTypes.NameIdentifier);

                if(userIdClaim !=null)
                {
                    var userIdValue = Int32.Parse(userIdClaim.Value);
                    var credential = (from c in db.Konto where c.ID_Konto == userIdValue select c).ToList();
                }

            }
            





            return View();
        }
    }
}
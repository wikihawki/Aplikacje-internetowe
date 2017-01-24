using Ogloszenia_Studenckie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ogloszenia_Studenckie.Controllers
{
    public class AccountController : Controller
    {
        private Aplikacje_InternetoweEntities1 db = new Aplikacje_InternetoweEntities1();
        [HttpGet]
        public ActionResult Login(string returnURL)
        {
            var userinfo = new LoginVM();

            try
            {
                // We do not want to use any existing identity information
                EnsureLoggedOut();

                // Store the originating URL so we can attach it to a form field
                userinfo.ReturnURL = returnURL;

                return View(userinfo);
            }
            catch
            {
                throw;
            }


        }
        //GET: EnsureLoggedOut
        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
                Logout();
        }

        //POST: Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            try
            {
                // First we clean the authentication ticket like always
                //required NameSpace: using System.Web.Security;
                FormsAuthentication.SignOut();

                // Second we clear the principal to ensure the user does not retain any authentication
                //required NameSpace: using System.Security.Principal;
                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

                Session.Clear();
                System.Web.HttpContext.Current.Session.RemoveAll();
                // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place
                // this clears the Request.IsAuthenticated flag since this triggers a new request
                return RedirectToAction("Index","Home");
            }
            catch
            {
                throw;
            }
        }

        //GET: SignInAsync
        private void SignInRemember(string userName, bool isPersistent = false)
        {
            // Clear any lingering authencation data
            FormsAuthentication.SignOut();

            // Write the authentication cookie
            FormsAuthentication.SetAuthCookie(userName, isPersistent);
        }

     
        private ActionResult RedirectToLocal(string returnURL = "")
        {
            try
            {
                // If the return url starts with a slash "/" we assume it belongs to our site
                // so we will redirect to this "action"
                if (!string.IsNullOrWhiteSpace(returnURL) && Url.IsLocalUrl(returnURL))
                    return Redirect(returnURL);

                // If we cannot verify if the url is local to our host we redirect to a default location
                return RedirectToAction("Index", "Dashboard");
            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM entity)
        {
            try
            {
                using (db = new Aplikacje_InternetoweEntities1())
                {
                    // Ensure we have a valid viewModel to work with
                    if (!ModelState.IsValid)
                        return View(entity);
                    var credential = (from c in db.Konto where c.E_Mail == entity.Username && c.Haslo == entity.Password select c).ToList();
                    if(credential.Count() == 0)
                    {
                        TempData["ErrorMSG"] = "Odmowa dostępu! Błędne dane logowania !";
                        return View(entity);
                    }
                    else {
                       
                        if (credential.Count() != 0)
                        {

                            var userInfo = credential.ElementAt(0);
                            //Login Success
                            //For Set Authentication in Cookie (Remeber ME Option)
                            SignInRemember(entity.Username, entity.isRemember);

                            //Set A Unique ID in session
                            Session["UserID"] = userInfo.ID_Konto;

                            // If we got this far, something failed, redisplay form
                            // return RedirectToAction("Index", "Dashboard");
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            //Login Fail
                            TempData["ErrorMSG"] = "Access Denied! Wrong Credential";
                            return View(entity);
                        }
                    }
                    
                }
            }
            catch
            {
                throw;
            }

        }
        [HttpGet]
        public ActionResult Register(string returnURL)
        {
            try
            {
                // We do not want to use any existing identity information
                EnsureLoggedOut();

                // Store the originating URL so we can attach it to a form field

                return View();
            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterVM entity)
        {
            if (ModelState.IsValid)
            {
                db.Konto.Add(new Konto
                {
                    Nazwa=entity.Nazwa,
                    E_Mail = entity.E_Mail,
                    Imie=entity.Imie,
                    Nazwisko=entity.Nazwisko,
                    Telefon=entity.Telefon,
                    Haslo=entity.Haslo,
                    Rola="2"
        });
                SaveChanges(db);
                ModelState.Clear();
                ViewBag.Message = "Rejestracja zakończona pomyślnie";
                return RedirectToAction("Index");
            }

            
            return RedirectToAction("Index", "Home");
        }

        private void SaveChanges(Aplikacje_InternetoweEntities1 context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }

    }

}
using Ogloszenia_Studenckie.DAL;
using Ogloszenia_Studenckie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace Ogloszenia_Studenckie.Controllers
{
    public class OfferController : Controller
    {
        [CheckAuthorization]
        // GET: Offer
        public ActionResult Index()
        {
            return View();
        }
        [CheckAuthorization]
        // GET: Offer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [CheckAuthorization]
        // GET: Offer/Create
        public ActionResult Create()
        {
            return View();
        }
        [CheckAuthorization]
        // POST: Offer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [CheckAuthorization]
        // GET: Offer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        [CheckAuthorization]
        // POST: Offer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [CheckAuthorization]
        // GET: Offer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        [CheckAuthorization]
        // POST: Offer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

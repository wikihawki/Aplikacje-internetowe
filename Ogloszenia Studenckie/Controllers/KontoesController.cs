using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ogloszenia_Studenckie;

namespace Ogloszenia_Studenckie.Controllers
{
    public class KontoesController : Controller
    {
        private Aplikacje_InternetoweEntities1 db = new Aplikacje_InternetoweEntities1();

        // GET: Kontoes
        public ActionResult Index()
        {
            return View(db.Konto.ToList());
        }

        // GET: Kontoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konto konto = db.Konto.Find(id);
            if (konto == null)
            {
                return HttpNotFound();
            }
            return View(konto);
        }

        // GET: Kontoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kontoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Konto,Nazwa,E_Mail,Imie,Nazwisko,Telefon,Haslo,Rola")] Konto konto)
        {
            if (ModelState.IsValid)
            {
                db.Konto.Add(konto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(konto);
        }

        // GET: Kontoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konto konto = db.Konto.Find(id);
            if (konto == null)
            {
                return HttpNotFound();
            }
            return View(konto);
        }

        // POST: Kontoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Konto,Nazwa,E_Mail,Imie,Nazwisko,Telefon,Haslo,Rola")] Konto konto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(konto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(konto);
        }

        // GET: Kontoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konto konto = db.Konto.Find(id);
            if (konto == null)
            {
                return HttpNotFound();
            }
            return View(konto);
        }

        // POST: Kontoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Konto konto = db.Konto.Find(id);
            db.Konto.Remove(konto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

﻿using System;
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
    public class OgloszeniesController : Controller
    {
        private Aplikacje_InternetoweEntities1 db = new Aplikacje_InternetoweEntities1();

        // GET: Ogloszenies
        public ActionResult Index(int? kat, int? mias, int? ucz, string szuk, int? page=1)
        {
            var ogloszenie = from a in db.Ogloszenie
                      where (a.ID_Uczelnia == ucz || ucz == null) && (a.ID_Kategoria == kat || a.Kategoria.NadKategoria == kat || kat == null) && (a.ID_Miasto == mias || mias == null)
                      && (a.Tytul.Contains(szuk) || a.Opis.Contains(szuk) || szuk==null)
                      select a;
            ViewBag.Kategorie = db.Kategoria;
            ViewBag.Miasta = db.Miasto;
            ViewBag.Uczelnie = db.Uczelnia;
            //var ogloszenie = db.Ogloszenie.Include(o => o.Kategoria).Include(o => o.Konto).Include(o => o.Miasto).Include(o => o.Uczelnia);
            return View(ogloszenie.ToList());
        }

        // GET: Ogloszenies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogloszenie ogloszenie = db.Ogloszenie.Find(id);
            if (ogloszenie == null)
            {
                return HttpNotFound();
            }
            return View(ogloszenie);
        }

        // GET: Ogloszenies/Create
        public ActionResult Create()
        {
            ViewBag.ID_Kategoria = new SelectList(db.Kategoria, "ID_Kategoria", "Nazwa");
            ViewBag.ID_Konto = new SelectList(db.Konto, "ID_Konto", "Nazwa");
            ViewBag.ID_Miasto = new SelectList(db.Miasto, "ID_Miasto", "Nazwa");
            ViewBag.ID_Uczelnia = new SelectList(db.Uczelnia, "ID_Uczelnia", "Nazwa");
            return View();
        }

        // POST: Ogloszenies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Ogloszenie,Tytul,Cena,Opis,Data_Zamkniecia,Data_Zamieszczenia,ID_Kategoria,ID_Konto,ID_Miasto,ID_Uczelnia")] Ogloszenie ogloszenie)
        {
            if (ModelState.IsValid)
            {
                db.Ogloszenie.Add(ogloszenie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Kategoria = new SelectList(db.Kategoria, "ID_Kategoria", "Nazwa", ogloszenie.ID_Kategoria);
            ViewBag.ID_Konto = new SelectList(db.Konto, "ID_Konto", "Nazwa", ogloszenie.ID_Konto);
            ViewBag.ID_Miasto = new SelectList(db.Miasto, "ID_Miasto", "Nazwa", ogloszenie.ID_Miasto);
            ViewBag.ID_Uczelnia = new SelectList(db.Uczelnia, "ID_Uczelnia", "Nazwa", ogloszenie.ID_Uczelnia);
            return View(ogloszenie);
        }

        // GET: Ogloszenies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogloszenie ogloszenie = db.Ogloszenie.Find(id);
            if (ogloszenie == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Kategoria = new SelectList(db.Kategoria, "ID_Kategoria", "Nazwa", ogloszenie.ID_Kategoria);
            ViewBag.ID_Konto = new SelectList(db.Konto, "ID_Konto", "Nazwa", ogloszenie.ID_Konto);
            ViewBag.ID_Miasto = new SelectList(db.Miasto, "ID_Miasto", "Nazwa", ogloszenie.ID_Miasto);
            ViewBag.ID_Uczelnia = new SelectList(db.Uczelnia, "ID_Uczelnia", "Nazwa", ogloszenie.ID_Uczelnia);
            return View(ogloszenie);
        }

        // POST: Ogloszenies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Ogloszenie,Tytul,Cena,Opis,Data_Zamkniecia,Data_Zamieszczenia,ID_Kategoria,ID_Konto,ID_Miasto,ID_Uczelnia")] Ogloszenie ogloszenie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogloszenie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Kategoria = new SelectList(db.Kategoria, "ID_Kategoria", "Nazwa", ogloszenie.ID_Kategoria);
            ViewBag.ID_Konto = new SelectList(db.Konto, "ID_Konto", "Nazwa", ogloszenie.ID_Konto);
            ViewBag.ID_Miasto = new SelectList(db.Miasto, "ID_Miasto", "Nazwa", ogloszenie.ID_Miasto);
            ViewBag.ID_Uczelnia = new SelectList(db.Uczelnia, "ID_Uczelnia", "Nazwa", ogloszenie.ID_Uczelnia);
            return View(ogloszenie);
        }

        // GET: Ogloszenies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogloszenie ogloszenie = db.Ogloszenie.Find(id);
            if (ogloszenie == null)
            {
                return HttpNotFound();
            }
            return View(ogloszenie);
        }

        // POST: Ogloszenies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ogloszenie ogloszenie = db.Ogloszenie.Find(id);
            db.Ogloszenie.Remove(ogloszenie);
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

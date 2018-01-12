using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Prog6.Controllers
{
    public class TamagotchisController : Controller
    {
        private Prog6Entities db = new Prog6Entities();

        // GET: Tamagotchis
        public ActionResult Index()
        {
            return View(db.Tamagotchis.ToList());
        }

        // GET: Tamagotchis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamagotchi tamagotchi = db.Tamagotchis.Find(id);
            if (tamagotchi == null)
            {
                return HttpNotFound();
            }
            return View(tamagotchi);
        }

        // GET: Tamagotchis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tamagotchis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naam,Leeftijd,Centjes,Level,Gezondheid,Verveling,Levend")] Tamagotchi tamagotchi)
        {
            if (ModelState.IsValid)
            {
                tamagotchi.Leeftijd = 0;
                tamagotchi.Centjes = 100;
                tamagotchi.Level = 0;
                tamagotchi.Gezondheid = 100;
                tamagotchi.Verveling = 0;
                tamagotchi.Levend = 1;
                db.Tamagotchis.Add(tamagotchi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tamagotchi);
        }

        // GET: Tamagotchis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamagotchi tamagotchi = db.Tamagotchis.Find(id);
            if (tamagotchi == null)
            {
                return HttpNotFound();
            }
            return View(tamagotchi);
        }

        // POST: Tamagotchis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naam,Leeftijd,Centjes,Level,Gezondheid,Verveling,Levend")] Tamagotchi tamagotchi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tamagotchi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tamagotchi);
        }

        // GET: Tamagotchis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamagotchi tamagotchi = db.Tamagotchis.Find(id);
            if (tamagotchi == null)
            {
                return HttpNotFound();
            }
            return View(tamagotchi);
        }

        // POST: Tamagotchis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tamagotchi tamagotchi = db.Tamagotchis.Find(id);
            db.Tamagotchis.Remove(tamagotchi);
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

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
    public class Hotelkamer_effectController : Controller
    {
        private Prog6Entities db = new Prog6Entities();

        // GET: Hotelkamer_effect
        public ActionResult Index()
        {
            var hotelkamer_effect = db.Hotelkamer_effect.Include(h => h.Hotelkamer_type);
            return View(hotelkamer_effect.ToList());
        }

        // GET: Hotelkamer_effect/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotelkamer_effect hotelkamer_effect = db.Hotelkamer_effect.Find(id);
            if (hotelkamer_effect == null)
            {
                return HttpNotFound();
            }
            return View(hotelkamer_effect);
        }

        // GET: Hotelkamer_effect/Create
        public ActionResult Create()
        {
            ViewBag.Type = new SelectList(db.Hotelkamer_type, "Type", "Type");
            return View();
        }

        // POST: Hotelkamer_effect/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Naam,Type,Eigenschap,Operator,Value")] Hotelkamer_effect hotelkamer_effect)
        {
            if (ModelState.IsValid)
            {
                db.Hotelkamer_effect.Add(hotelkamer_effect);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type = new SelectList(db.Hotelkamer_type, "Type", "Type", hotelkamer_effect.Type);
            return View(hotelkamer_effect);
        }

        // GET: Hotelkamer_effect/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotelkamer_effect hotelkamer_effect = db.Hotelkamer_effect.Find(id);
            if (hotelkamer_effect == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type = new SelectList(db.Hotelkamer_type, "Type", "Type", hotelkamer_effect.Type);
            return View(hotelkamer_effect);
        }

        // POST: Hotelkamer_effect/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Naam,Type,Eigenschap,Operator,Value")] Hotelkamer_effect hotelkamer_effect)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelkamer_effect).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type = new SelectList(db.Hotelkamer_type, "Type", "Type", hotelkamer_effect.Type);
            return View(hotelkamer_effect);
        }

        // GET: Hotelkamer_effect/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotelkamer_effect hotelkamer_effect = db.Hotelkamer_effect.Find(id);
            if (hotelkamer_effect == null)
            {
                return HttpNotFound();
            }
            return View(hotelkamer_effect);
        }

        // POST: Hotelkamer_effect/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hotelkamer_effect hotelkamer_effect = db.Hotelkamer_effect.Find(id);
            db.Hotelkamer_effect.Remove(hotelkamer_effect);
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

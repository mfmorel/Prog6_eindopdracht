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
    public class HotelkamersController : Controller
    {
        private Prog6Entities db = new Prog6Entities();

        // GET: Hotelkamers
        public ActionResult Index()
        {
            var hotelkamers = db.Hotelkamers.Include(h => h.Hotelkamer_type);
            return View(hotelkamers.ToList());
        }

        // GET: Hotelkamers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotelkamer hotelkamer = db.Hotelkamers.Find(id);
            if (hotelkamer == null)
            {
                return HttpNotFound();
            }
            return View(hotelkamer);
        }

        // GET: Hotelkamers/Create
        public ActionResult Create()
        {
            ViewBag.Type = new SelectList(db.Hotelkamer_type, "Type", "Type");
            return View();
        }

        // POST: Hotelkamers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Groote,Type")] Hotelkamer hotelkamer)
        {
            if (ModelState.IsValid)
            {
                db.Hotelkamers.Add(hotelkamer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type = new SelectList(db.Hotelkamer_type, "Type", "Type", hotelkamer.Type);
            return View(hotelkamer);
        }

        // GET: Hotelkamers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotelkamer hotelkamer = db.Hotelkamers.Find(id);
            if (hotelkamer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type = new SelectList(db.Hotelkamer_type, "Type", "Type", hotelkamer.Type);
            return View(hotelkamer);
        }

        // POST: Hotelkamers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Groote,Type")] Hotelkamer hotelkamer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelkamer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type = new SelectList(db.Hotelkamer_type, "Type", "Type", hotelkamer.Type);
            return View(hotelkamer);
        }

        // GET: Hotelkamers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotelkamer hotelkamer = db.Hotelkamers.Find(id);
            if (hotelkamer == null)
            {
                return HttpNotFound();
            }
            return View(hotelkamer);
        }

        // POST: Hotelkamers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotelkamer hotelkamer = db.Hotelkamers.Find(id);
            db.Hotelkamers.Remove(hotelkamer);
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

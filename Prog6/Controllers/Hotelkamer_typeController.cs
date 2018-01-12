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
    public class Hotelkamer_typeController : Controller
    {
        private Prog6Entities db = new Prog6Entities();

        // GET: Hotelkamer_type
        public ActionResult Index()
        {
            return View(db.Hotelkamer_type.ToList());
        }

        // GET: Hotelkamer_type/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotelkamer_type hotelkamer_type = db.Hotelkamer_type.Find(id);
            if (hotelkamer_type == null)
            {
                return HttpNotFound();
            }
            return View(hotelkamer_type);
        }

        // GET: Hotelkamer_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotelkamer_type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Type,Kosten")] Hotelkamer_type hotelkamer_type)
        {
            if (ModelState.IsValid)
            {
                db.Hotelkamer_type.Add(hotelkamer_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotelkamer_type);
        }

        // GET: Hotelkamer_type/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotelkamer_type hotelkamer_type = db.Hotelkamer_type.Find(id);
            if (hotelkamer_type == null)
            {
                return HttpNotFound();
            }
            return View(hotelkamer_type);
        }

        // POST: Hotelkamer_type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Type,Kosten")] Hotelkamer_type hotelkamer_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelkamer_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotelkamer_type);
        }

        // GET: Hotelkamer_type/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotelkamer_type hotelkamer_type = db.Hotelkamer_type.Find(id);
            if (hotelkamer_type == null)
            {
                return HttpNotFound();
            }
            return View(hotelkamer_type);
        }

        // POST: Hotelkamer_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hotelkamer_type hotelkamer_type = db.Hotelkamer_type.Find(id);
            db.Hotelkamer_type.Remove(hotelkamer_type);
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

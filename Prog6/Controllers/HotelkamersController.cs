using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain;
using Prog6.Interfaces;

namespace Prog6.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HotelkamersController : Controller
    {
        private IContext db;

        public HotelkamersController()
        {
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
        }

        [ImportingConstructor]
        public HotelkamersController(IContext context)
        {
            db = context;
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
        }

        // GET: Hotelkamers
        public ActionResult Index()
        {
            var hotelkamers = db.GetContext().Hotelkamers.Include(h => h.Hotelkamer_type);
            return View(hotelkamers.ToList());
        }

        // GET: Hotelkamers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotelkamer hotelkamer = db.GetContext().Hotelkamers.Find(id);
            if (hotelkamer == null)
            {
                return HttpNotFound();
            }
            return View(hotelkamer);
        }

        // GET: Hotelkamers/Create
        public ActionResult Create()
        {
            ViewBag.Type = new SelectList(db.GetContext().Hotelkamer_type, "Type", "Type");
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
                db.GetContext().Hotelkamers.Add(hotelkamer);
                db.GetContext().SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type = new SelectList(db.GetContext().Hotelkamer_type, "Type", "Type", hotelkamer.Type);
            return View(hotelkamer);
        }

        // GET: Hotelkamers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotelkamer hotelkamer = db.GetContext().Hotelkamers.Find(id);
            if (hotelkamer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type = new SelectList(db.GetContext().Hotelkamer_type, "Type", "Type", hotelkamer.Type);
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
                db.GetContext().Entry(hotelkamer).State = EntityState.Modified;
                db.GetContext().SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type = new SelectList(db.GetContext().Hotelkamer_type, "Type", "Type", hotelkamer.Type);
            return View(hotelkamer);
        }

        // GET: Hotelkamers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotelkamer hotelkamer = db.GetContext().Hotelkamers.Find(id);
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
            Hotelkamer hotelkamer = db.GetContext().Hotelkamers.Find(id);
            db.GetContext().Hotelkamers.Remove(hotelkamer);
            db.GetContext().SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.GetContext().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

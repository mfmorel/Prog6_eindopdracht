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
    public class Hotelkamer_typeController : Controller
    {
        private IContext db;

        public Hotelkamer_typeController()
        {
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
        }

        [ImportingConstructor]
        public Hotelkamer_typeController(IContext context)
        {
            db = context;
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
        }

        // GET: Hotelkamer_type
        public ActionResult Index()
        {
            return View(db.GetContext().Hotelkamer_type.ToList());
        }

        // GET: Hotelkamer_type/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotelkamer_type hotelkamer_type = db.GetContext().Hotelkamer_type.Find(id);
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
                db.GetContext().Hotelkamer_type.Add(hotelkamer_type);
                db.GetContext().SaveChanges();
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
            Hotelkamer_type hotelkamer_type = db.GetContext().Hotelkamer_type.Find(id);
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
                db.GetContext().Entry(hotelkamer_type).State = EntityState.Modified;
                db.GetContext().SaveChanges();
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
            Hotelkamer_type hotelkamer_type = db.GetContext().Hotelkamer_type.Find(id);
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
            Hotelkamer_type hotelkamer_type = db.GetContext().Hotelkamer_type.Find(id);
            db.GetContext().Hotelkamer_type.Remove(hotelkamer_type);
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

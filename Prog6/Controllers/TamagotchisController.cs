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
    public class TamagotchisController : Controller
    {
        private IContext db;

        public TamagotchisController()
        {
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
        }

        [ImportingConstructor]
        public TamagotchisController(IContext context)
        {
            db = context;
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
        }

        // GET: Tamagotchis
        public ActionResult Index()
        {
            return View(db.GetContext().Tamagotchis.ToList());
        }

        // GET: Tamagotchis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamagotchi tamagotchi = db.GetContext().Tamagotchis.Find(id);
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
                db.GetContext().Tamagotchis.Add(tamagotchi);
                db.GetContext().SaveChanges();
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
            Tamagotchi tamagotchi = db.GetContext().Tamagotchis.Find(id);
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
                db.GetContext().Entry(tamagotchi).State = EntityState.Modified;
                db.GetContext().SaveChanges();
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
            Tamagotchi tamagotchi = db.GetContext().Tamagotchis.Find(id);
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
            Tamagotchi tamagotchi = db.GetContext().Tamagotchis.Find(id);
            db.GetContext().Tamagotchis.Remove(tamagotchi);
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

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
using Ninject;
using Prog6.Interfaces;
using Prog6.Models;
using Prog6.Respositories.Interfaces;

namespace Prog6.Controllers
{
    public class TamagotchisController : Controller
    {
        private ITamagotchiRepository _tamagotchiRepository;

        [Inject]
        public TamagotchisController(ITamagotchiRepository tamagotchiRepository)
        {
            _tamagotchiRepository = tamagotchiRepository;
        }

        // GET: Tamagotchis
        public ActionResult Index()
        {
            return View(_tamagotchiRepository.GetAll());
        }

        // GET: Tamagotchis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TamagotchiModel tamagotchi = _tamagotchiRepository.Get(id.Value);

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
        // [Bind(Include = "Id,Naam,Leeftijd,Centjes,Level,Gezondheid,Verveling,Levend")] Tamagotchi tamagotchi
        public ActionResult Create(TamagotchiModel tamagotchi)
        {
            if (ModelState.IsValid)
            {
                tamagotchi.Leeftijd = 0;
                tamagotchi.Centjes = 100;
                tamagotchi.Level = 0;
                tamagotchi.Gezondheid = 100;
                tamagotchi.Verveling = 0;
                tamagotchi.Levend = 1;
                _tamagotchiRepository.Create(tamagotchi);
                _tamagotchiRepository.Save();
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
            TamagotchiModel tamagotchi = _tamagotchiRepository.Get(id.Value);
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
        // [Bind(Include = "Id,Naam,Leeftijd,Centjes,Level,Gezondheid,Verveling,Levend")] Tamagotchi tamagotchi
        public ActionResult Edit(TamagotchiModel tamagotchi)
        {
            if (ModelState.IsValid)
            {
                //Tamagotchi t1 = db.GetContext().Tamagotchis.Where(t => t.Id == tamagotchi.Id).FirstOrDefault();
                //t1.Naam = tamagotchi.Naam;
                _tamagotchiRepository.Update(tamagotchi);
                _tamagotchiRepository.Save();
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
            TamagotchiModel tamagotchi = _tamagotchiRepository.Get(id.Value);
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
            TamagotchiModel tamagotchi = _tamagotchiRepository.Get(id);
            _tamagotchiRepository.Delete(tamagotchi);
            _tamagotchiRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                //db.GetContext().Dispose();
            }
            base.Dispose(disposing);*/
        }
    }
}

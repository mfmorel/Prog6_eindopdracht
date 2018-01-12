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
using Prog6.Models;
using Prog6.Respositories.Interfaces;

namespace Prog6.Controllers
{
    public class Hotelkamer_effectController : Controller
    {
        private IHotelkamerEffectRepository _hotelkamerEffectRepository;
        private IHotelkamerTypeRepository _hotelkamerTypeRepository;

        public Hotelkamer_effectController(IHotelkamerEffectRepository hotelkamerEffectRepository, IHotelkamerTypeRepository hotelkamerTypeRepository)
        {
            _hotelkamerEffectRepository = hotelkamerEffectRepository;
            _hotelkamerTypeRepository = hotelkamerTypeRepository;
        }

        // GET: Hotelkamer_effect
        public ActionResult Index()
        {
            // var hotelkamer_effect = db.GetContext().Hotelkamer_effect.Include(h => h.Hotelkamer_type);
            var hotelkamer_effect = _hotelkamerEffectRepository.GetAll();
            return View(hotelkamer_effect);
        }

        // GET: Hotelkamer_effect/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelkamerEffectModel hotelkamer_effect = _hotelkamerEffectRepository.Get(id);
            if (hotelkamer_effect == null)
            {
                return HttpNotFound();
            }
            return View(hotelkamer_effect);
        }

        // GET: Hotelkamer_effect/Create
        public ActionResult Create()
        {
            ViewBag.Type = new SelectList(_hotelkamerTypeRepository.GetAll(), "Type", "Type");
            return View();
        }

        // POST: Hotelkamer_effect/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HotelkamerEffectModel hotelkamerEffect)
        {
            if (ModelState.IsValid)
            {
                _hotelkamerEffectRepository.Create(hotelkamerEffect);
                _hotelkamerEffectRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Type = new SelectList(_hotelkamerTypeRepository.GetAll(), "Type", "Type", hotelkamerEffect.Type);
            return View(hotelkamerEffect);
        }

        // GET: Hotelkamer_effect/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelkamerEffectModel hotelkamer_effect = _hotelkamerEffectRepository.Get(id);
            if (hotelkamer_effect == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type = new SelectList(_hotelkamerTypeRepository.GetAll(), "Type", "Type", hotelkamer_effect.Type);
            return View(hotelkamer_effect);
        }

        // POST: Hotelkamer_effect/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HotelkamerEffectModel hotelkamerEffectModel)
        {
            if (ModelState.IsValid)
            {
                _hotelkamerEffectRepository.Update(hotelkamerEffectModel);
                _hotelkamerEffectRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Type = new SelectList(_hotelkamerTypeRepository.GetAll(), "Type", "Type", hotelkamerEffectModel.Type);
            return View(hotelkamerEffectModel);
        }

        // GET: Hotelkamer_effect/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelkamerEffectModel hotelkamer_effect = _hotelkamerEffectRepository.Get(id);
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
            HotelkamerEffectModel hotelkamer_effect = _hotelkamerEffectRepository.Get(id);
            _hotelkamerEffectRepository.Delete(hotelkamer_effect);
            _hotelkamerEffectRepository.Save();
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

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
using Prog6.Kamers;
using Prog6.Models;
using Prog6.Respositories.Interfaces;

namespace Prog6.Controllers
{
    public class HotelkamersController : Controller
    {
        private IHotelkamerRepository _hotelkamerRepository;

        public HotelkamersController(IHotelkamerRepository hotelkamerRepository)
        {
            _hotelkamerRepository = hotelkamerRepository;
        }
        // GET: Hotelkamers
        public ActionResult Index()
        {
            return View(_hotelkamerRepository.GetAll());
        }

        // GET: Hotelkamers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelkamerModel hotelkamer = _hotelkamerRepository.Get(id.Value);
            if (hotelkamer == null)
            {
                return HttpNotFound();
            }
            return View(hotelkamer);
        }

        // GET: Hotelkamers/Create
        public ActionResult Create()
        {
            int[] Groote = new[] {2, 3, 5 };
            ViewBag.Groote = new SelectList(Groote);
            ViewBag.Type = new SelectList(Kamer.GetKamers());
            return View();
        }

        // POST: Hotelkamers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Bind(Include = "Id,Groote,Type")] Hotelkamer hotelkamer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HotelkamerModel hotelkamer)
        {
            if (ModelState.IsValid)
            {
                _hotelkamerRepository.Create(hotelkamer);
                _hotelkamerRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Type = new SelectList(Kamer.GetKamers(), hotelkamer.Type);

            return View(hotelkamer);
        }

        // GET: Hotelkamers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelkamerModel hotelkamer = _hotelkamerRepository.Get(id.Value);
            if (hotelkamer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type = new SelectList(Kamer.GetKamers());
            ViewBag.Groote = new SelectList(new int[] {2, 3, 5}, hotelkamer.Groote);
            return View(hotelkamer);
        }

        // POST: Hotelkamers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Bind(Include = "Id,Groote,Type")] Hotelkamer hotelkamer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HotelkamerModel hotelkamer)
        {
            if (ModelState.IsValid)
            {
                _hotelkamerRepository.Update(hotelkamer);
                _hotelkamerRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Type = new SelectList(Kamer.GetKamers(), hotelkamer.Type);
            return View(hotelkamer);
        }

        // GET: Hotelkamers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelkamerModel hotelkamer = _hotelkamerRepository.Get(id.Value);
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
            HotelkamerModel tamagotchi = _hotelkamerRepository.Get(id);
            _hotelkamerRepository.Delete(tamagotchi);
            _hotelkamerRepository.Save();
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

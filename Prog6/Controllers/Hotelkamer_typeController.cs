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
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class Hotelkamer_typeController : Controller
    {
        private IHotelkamerTypeRepository _hotelkamerTypeRepository;
        public Hotelkamer_typeController(IHotelkamerTypeRepository hotelkamerTypeRepository)
        {
            _hotelkamerTypeRepository = hotelkamerTypeRepository;
        }

        // GET: Hotelkamer_type
        public ActionResult Index()
        {
            return View(_hotelkamerTypeRepository.GetAll());
        }

        // GET: Hotelkamer_type/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelkamerTypeModel hotelkamer_type = _hotelkamerTypeRepository.Get(id);
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
        public ActionResult Create(HotelkamerTypeModel hotelkamerType)
        {
            if (ModelState.IsValid)
            {
                _hotelkamerTypeRepository.Create(hotelkamerType);
                return RedirectToAction("Index");
            }

            return View(hotelkamerType);
        }

        // GET: Hotelkamer_type/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelkamerTypeModel hotelKamerType = _hotelkamerTypeRepository.Get(id);
            if (hotelKamerType == null)
            {
                return HttpNotFound();
            }
            return View(hotelKamerType);
        }

        // POST: Hotelkamer_type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HotelkamerTypeModel hotelkamerType)
        {
            if (ModelState.IsValid)
            {
                _hotelkamerTypeRepository.Update(hotelkamerType);
                _hotelkamerTypeRepository.Save();
                return RedirectToAction("Index");
            }
            return View(hotelkamerType);
        }

        // GET: Hotelkamer_type/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelkamerTypeModel hotelkamerType = _hotelkamerTypeRepository.Get(id);
            if (hotelkamerType == null)
            {
                return HttpNotFound();
            }
            return View(hotelkamerType);
        }

        // POST: Hotelkamer_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HotelkamerTypeModel hotelkamerType = _hotelkamerTypeRepository.Get(id);
            _hotelkamerTypeRepository.Delete(hotelkamerType);
            _hotelkamerTypeRepository.Save();
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

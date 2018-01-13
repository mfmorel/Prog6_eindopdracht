using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prog6.Controllers
{
    public class BoekenController : Controller
    {
        // GET: Boeken
        public ActionResult Index()
        {
            return View();
        }

        // GET: Boeken/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Boeken/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boeken/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Boeken/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Boeken/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Boeken/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Boeken/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

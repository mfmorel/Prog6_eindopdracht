using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using Prog6.Kamers;
using Prog6.Models;
using Prog6.Respositories.Interfaces;

namespace Prog6.Controllers
{
    public class BoekingController : Controller
    {
        private IBoekingRepository _boekingRepository;
        private IHotelkamerRepository _hotelkamerRepository;
        private ITamagotchiRepository _tamagotchiRepository;

        public BoekingController(IBoekingRepository boekingRepository, IHotelkamerRepository hotelkamerRepository, ITamagotchiRepository tamagotchiRepository)
        {
            _boekingRepository = boekingRepository;
            _hotelkamerRepository = hotelkamerRepository;
            _tamagotchiRepository = tamagotchiRepository;
        }
        // GET: Boeking
        public ActionResult Index()
        {
            return View(_boekingRepository.GetAvailableRooms());
        }

        public ActionResult Tamagotchis(int id)
        {
            BoekingModel boekingModel = new BoekingModel();
            HotelkamerModel hotelkamer = _hotelkamerRepository.Get(id);
            hotelkamer.Prijs = Kamer.GetKamer(hotelkamer.Type).Price;

            if (hotelkamer != null)
                boekingModel.Hotelkamer = hotelkamer;

            List<TamagotchiModel> tamagotchis = _tamagotchiRepository.GetAllAlive().Where(t => t.Centjes >= hotelkamer.Prijs).ToList();
            if (tamagotchis.Count > 0)
            {
                boekingModel.AvTamagotchis = tamagotchis;
                return View(boekingModel);
            }

            return Index();
        }

        [HttpPost]
        public ActionResult Book(BoekingModel boeking)
        {
            boeking.Tamagotchis = boeking.AvTamagotchis.Where(m => m.IsSelected == true).ToList();

            if (boeking.Tamagotchis == null)
                return RedirectToAction("Tamagotchis", "Boeking", new {id = boeking.Hotelkamer.Id});

            return View(boeking);
        }

        [HttpPost]
        public ActionResult Confirm(BoekingModel boeking)
        {
            _boekingRepository.Create(boeking);
            _boekingRepository.Save();

            return View();
        }
    }
}
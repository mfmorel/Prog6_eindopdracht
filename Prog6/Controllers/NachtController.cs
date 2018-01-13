using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prog6.Kamers;
using Prog6.Models;
using Prog6.Respositories.Interfaces;

namespace Prog6.Controllers
{
    public class NachtController : Controller
    {
        private IHotelkamerRepository _hotelkamerRepository;
        private IBoekingRepository _boekingRepository;

        public NachtController(IHotelkamerRepository hotelkamerRepository, IBoekingRepository boekingRepository)
        {
            _hotelkamerRepository = hotelkamerRepository;
            _boekingRepository = boekingRepository;
        }

        // GET: Nacht
        public ActionResult Index()
        {
            // List<BoekingModel> boekingen = _boekingRepository.GetAll();
            _hotelkamerRepository.GetAll().ForEach(k =>
            {
                IKamer kamer = Kamer.GetKamer(k.Type);
                kamer.Nacht(k.Tamagotchis.Select(t => new TamagotchiModel() {_tamagotchi = t}).ToList());
                _hotelkamerRepository.Update(k);
                _hotelkamerRepository.Save();
                k.Tamagotchis.Clear();
                _hotelkamerRepository.Update(k);
                _hotelkamerRepository.Save();
            });

            ViewBag.NachtComplete = "Er is een nieuwe dag aangebroken!";

            return RedirectToAction("Index", "Home");
        }
    }
}
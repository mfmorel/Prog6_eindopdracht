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
        private ITamagotchiRepository _tamagotchiRepository;

        public NachtController(IHotelkamerRepository hotelkamerRepository, IBoekingRepository boekingRepository, ITamagotchiRepository tamagotchiRepository)
        {
            _hotelkamerRepository = hotelkamerRepository;
            _boekingRepository = boekingRepository;
            _tamagotchiRepository = tamagotchiRepository;
        }

        // GET: Nacht
        public ActionResult Index()
        {
            List<TamagotchiModel> RoomlessTamagotchis = _tamagotchiRepository.GetAllAlive();
            _hotelkamerRepository.GetAll().Where(t => t.Tamagotchis.Count > 0).ToList().ForEach((h) =>
            {
                foreach (var objTamagotchi in h.Tamagotchis)
                {
                    for (int i = 0; i < RoomlessTamagotchis.Count; i++)
                    {
                        if (RoomlessTamagotchis[i].Id == objTamagotchi.Id)
                        {
                            RoomlessTamagotchis.Remove(RoomlessTamagotchis[i]);
                            i--;
                        }
                    }
                }
            });

            RoomlessTamagotchis.ForEach((t) =>
            {
                t.Verveling += 20;
                t.Gezondheid -= 20;
                t.Leeftijd += 1;
                t.Level += 1;
                _tamagotchiRepository.Update(t);
            });
            _tamagotchiRepository.Save();

            _hotelkamerRepository.GetAll().Where(h => h.Tamagotchis.Count > 0).ToList().ForEach(k =>
            {
                IKamer kamer = Kamer.GetKamer(k.Type);
                kamer.Nacht(k.Tamagotchis.Select(t => new TamagotchiModel() {_tamagotchi = t}).ToList());
                _hotelkamerRepository.Update(k);
                _hotelkamerRepository.Save();
                k.Tamagotchis.Clear();
                _hotelkamerRepository.Update(k);
                _hotelkamerRepository.Save();
            });

            TempData["NachtComplete"] = "Er is een nieuwe dag aangebroken!";

            return RedirectToAction("Index", "Home");
        }
    }
}
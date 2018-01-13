using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Prog6.Interfaces;
using Prog6.Respositories.Interfaces;
using Prog6.Models;

namespace Prog6.Controllers
{
    public class HomeController : Controller
    {
        private ITamagotchiRepository _tamagotchiRepository;
        private IHotelkamerRepository _hotelkamerRepository;

        public HomeController(ITamagotchiRepository tamagotchiRepository, IHotelkamerRepository hotelkamerRepository)
        {
            _tamagotchiRepository = tamagotchiRepository;
            _hotelkamerRepository = hotelkamerRepository;
        }        

        public ActionResult Index()
        {
            List<TamagotchiModel> AllTamagotchis = _tamagotchiRepository.GetAll();
            List<TamagotchiModel> AliveTamagotchis = AllTamagotchis.Where(t => t.Levend == 1).ToList();
            List<TamagotchiModel> DeadTamagotchis = AllTamagotchis.Where(t => t.Levend == 0).ToList();
            List<TamagotchiModel> RoomlessTamagotchis = new List<TamagotchiModel>(AliveTamagotchis);
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
            return View(new HomeIndexModel()
            {
                AllTamagotchis = AllTamagotchis,
                AliveTamagotchis = AliveTamagotchis,
                DeadTamagotchis =  DeadTamagotchis,
                RoomlessTamagotchis = RoomlessTamagotchis
            });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
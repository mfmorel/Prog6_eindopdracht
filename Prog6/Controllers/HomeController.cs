using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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

        public HomeController(ITamagotchiRepository tamagotchiRepository)
        {
            _tamagotchiRepository = tamagotchiRepository;
        }        

        public ActionResult Index()
        {
            List<TamagotchiModel> tamagotchis = _tamagotchiRepository.GetAll();
            /*List<Tamagotchi> aliveTamagotchis = tamagotchis.Where(t => t.Levend == 1).ToList();
            List<Tamagotchi> deadTamagotchis = tamagotchis.Where(t => t.Levend == 0).ToList();
            db.Hotelkamers.ToList().ForEach((h) =>
            {
                if (h.Tamagotchis.Count > 0)
                {
                    foreach (var objTamagotchi in h.Tamagotchis)
                    {
                        if (tamagotchis.Contains(objTamagotchi))
                            tamagotchis.Remove(objTamagotchi);
                    }
                }
            });*/
            Console.Write(tamagotchis);
            return View();
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
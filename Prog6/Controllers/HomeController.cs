using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Prog6.Controllers
{
    public class HomeController : Controller
    {
        private Prog6Entities db = new Prog6Entities();

        public ActionResult Index()
        {
            List<Tamagotchi> tamagotchis = db.Tamagotchis.ToList();
            List<Tamagotchi> aliveTamagotchis = tamagotchis.Where(t => t.Levend == 1).ToList();
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
            });


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
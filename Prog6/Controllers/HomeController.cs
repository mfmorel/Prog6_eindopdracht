using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Prog6.Interfaces;

namespace Prog6.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : Controller
    {
        private IContext db;

        public HomeController()
        {
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
        }

        [ImportingConstructor]
        public HomeController(IContext context)
        {
            db = context;
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
        }

        public ActionResult Index()
        {
            List<Tamagotchi> tamagotchis = db.GetContext().Tamagotchis.ToList();
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
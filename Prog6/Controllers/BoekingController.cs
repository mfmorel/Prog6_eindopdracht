using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prog6.Models;
using Prog6.Respositories.Interfaces;

namespace Prog6.Controllers
{
    public class BoekingController : Controller
    {
        private IBoekingRepository _boekingRepository;
        private IHotelkamerRepository _hotelkamerRepository;
        private ITamagotchiRepository _tamagotchiRepository;
        private BoekingModel _boekingModel;

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
            _boekingModel = new BoekingModel();
            HotelkamerModel hotelkamer = _hotelkamerRepository.Get(id);
            if (hotelkamer != null)
                _boekingModel.Hotelkamer = hotelkamer;

            List<TamagotchiModel> tamagotchis = _tamagotchiRepository.GetAllAlive();
            if (tamagotchis != null && tamagotchis.Count > 0)
            {
                _boekingModel.Tamagotchis = tamagotchis;
                return View(_boekingModel);
            }

            return Index();
        }

    }
}
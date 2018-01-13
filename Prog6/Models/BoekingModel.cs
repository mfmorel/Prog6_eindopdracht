using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prog6.Models
{
    public class BoekingModel
    {
        public HotelkamerModel Hotelkamer { get; set; }
        public List<TamagotchiModel> Tamagotchis { get; set; }

        public BoekingModel()
        {
            Hotelkamer = new HotelkamerModel();
            Tamagotchis = new List<TamagotchiModel>();
        }

        public BoekingModel(HotelkamerModel hotelkamer, List<TamagotchiModel> tamagotchis)
        {
            Hotelkamer = hotelkamer;
            Tamagotchis = tamagotchis;
        }
    }
}
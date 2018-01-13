using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prog6.Models
{
    public class BoekingModel
    {
        public HotelkamerModel Hotelkamer { get; set; }
        private List<TamagotchiModel> _tamagotchis;

        public List<TamagotchiModel> Tamagotchis
        {
            get { return _tamagotchis; }
            set
            {
                if (value.Count > 0 && value.Count <= Hotelkamer.Groote)
                    _tamagotchis = value;
                else
                    _tamagotchis = null;
            }
        }

        public List<TamagotchiModel> AvTamagotchis { get; set; }

        public BoekingModel()
        {
            Hotelkamer = new HotelkamerModel();
            Tamagotchis = new List<TamagotchiModel>();
            AvTamagotchis = new List<TamagotchiModel>();
        }

        public BoekingModel(HotelkamerModel hotelkamer, List<TamagotchiModel> tamagotchis)
        {
            Hotelkamer = hotelkamer;
            Tamagotchis = tamagotchis;
        }
    }
}
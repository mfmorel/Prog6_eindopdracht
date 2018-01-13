using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using Prog6.Respositories.Interfaces;

namespace Prog6.Models
{
    public class HotelkamerModel
    {
        public Hotelkamer _Hotelkamer;

        public int Id
        {
            get { return _Hotelkamer.Id; }
            set { _Hotelkamer.Id = value; }
        }

        public int Groote
        {
            get { return _Hotelkamer.Groote; }
            set { _Hotelkamer.Groote = value; }
        }

        public ICollection<Tamagotchi> Tamagotchis
        {
            get { return _Hotelkamer.Tamagotchis; }
            set { _Hotelkamer.Tamagotchis = value; }
        }

        public string Type
        {
            get { return _Hotelkamer.Type; }
            set { _Hotelkamer.Type = value; }
        }

        public Hotelkamer_type Hotelkamer_type
        {
            get { return _Hotelkamer.Hotelkamer_type; }
            set { _Hotelkamer.Hotelkamer_type = value; }
        }

        public HotelkamerModel(Hotelkamer hotelkamer)
        {
            _Hotelkamer = hotelkamer;
        }

        public HotelkamerModel()
        {
            _Hotelkamer = new Hotelkamer();
        }

        public Hotelkamer ToModel()
        {
            return _Hotelkamer;
        } 
    }
}
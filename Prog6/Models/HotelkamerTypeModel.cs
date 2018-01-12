using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Prog6.Models
{
    public class HotelkamerTypeModel
    {
        public Hotelkamer_type _hotelkamerType { get; set; }

        public string Type
        {
            get{ return _hotelkamerType.Type; }
            set { _hotelkamerType.Type = value; }
        }

        public int? Kosten
        {
            get { return _hotelkamerType.Kosten; }
            set { _hotelkamerType.Kosten = value; }
        }

        public HotelkamerTypeModel()
        {
            _hotelkamerType = new Hotelkamer_type();
        }

        public HotelkamerTypeModel(Hotelkamer_type hotelkamerType)
        {
            _hotelkamerType = hotelkamerType;
        }

        public Hotelkamer_type ToModel()
        {
            return _hotelkamerType;
        }
    }
}
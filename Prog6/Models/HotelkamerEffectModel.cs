using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Prog6.Models
{
    public class HotelkamerEffectModel
    {
        public Hotelkamer_effect _hotelkamerEffect { get; set; }

        public string Naam
        {
            get { return _hotelkamerEffect.Naam; }
            set { _hotelkamerEffect.Naam = value; }
        }

        public string Eigenschap
        {
            get { return _hotelkamerEffect.Eigenschap; }
            set { _hotelkamerEffect.Eigenschap = value; }
        }

        public string Operator
        {
            get { return _hotelkamerEffect.Operator; }
            set { _hotelkamerEffect.Operator = value; }
        }

        public string Type
        {
            get { return _hotelkamerEffect.Type; }
            set { _hotelkamerEffect.Type = value; }
        }

        public string Value
        {
            get { return _hotelkamerEffect.Value; }
            set { _hotelkamerEffect.Value = value; }
        }

        public Hotelkamer_type HotelkamerType
        {
            get { return _hotelkamerEffect.Hotelkamer_type; }
            set { _hotelkamerEffect.Hotelkamer_type = value; }
        }

        public HotelkamerEffectModel(Hotelkamer_effect hotelkamerEffect)
        {
            _hotelkamerEffect = hotelkamerEffect;
        }

        public HotelkamerEffectModel()
        {
           _hotelkamerEffect = new Hotelkamer_effect();
        }

        public Hotelkamer_effect ToModel()
        {
            return _hotelkamerEffect;
        }
    }
}
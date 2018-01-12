using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain;

namespace Prog6.Models
{
    public class TamagotchiModel
    {
        private Tamagotchi _tamagotchi;

        public int Id
        {
            get { return _tamagotchi.Id; }
            // ?????
            set { _tamagotchi.Id = value; }
        }

        public string Naam
        {
            get { return _tamagotchi.Naam; }
            set { _tamagotchi.Naam = value; }
        }

        public int Centjes
        {
            get { return _tamagotchi.Centjes; }
            set { _tamagotchi.Centjes = value; }
        }

        public int Gezondheid
        {
            get { return _tamagotchi.Gezondheid; }
            set { _tamagotchi.Gezondheid = value; }
        }

        public int Level
        {
            get { return _tamagotchi.Level; }
            set { _tamagotchi.Level = value; }
        }

        public int Leeftijd
        {
            get { return _tamagotchi.Leeftijd; }
            set { _tamagotchi.Leeftijd = value; }
        }

        public ICollection<Hotelkamer> HotelKamers
        {
            get { return _tamagotchi.Hotelkamers; }
            set { _tamagotchi.Hotelkamers = value; }
        }

        public byte Levend
        {
            get { return _tamagotchi.Levend; }
            set { _tamagotchi.Levend = value; }
        }

        public int Verveling
        {
            get { return _tamagotchi.Verveling; }
            set { _tamagotchi.Verveling = value; }
        }

        public TamagotchiModel(Tamagotchi tamagotchi)
        {
            _tamagotchi = tamagotchi;
        }

        public TamagotchiModel()
        {
            _tamagotchi = new Tamagotchi();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain;

namespace Prog6.Models
{
    public class TamagotchiModel
    {
        public Tamagotchi _tamagotchi { get; set; }

        public int Id
        {
            get { return _tamagotchi.Id; }
            set { _tamagotchi.Id = value; }
        }

        [Required]
        [MaxLength(10)]
        public string Naam
        {
            get { return _tamagotchi.Naam; }
            set { _tamagotchi.Naam = value; }
        }

        [Required]
        [DefaultValue(100)]
        [Range(0, 1000000000000)]
        public int Centjes
        {
            get { return _tamagotchi.Centjes; }
            set
            {
                _tamagotchi.Centjes = value;
                if (Centjes < 0)
                {
                    _tamagotchi.Centjes = 0;
                }
            }
        }

        [Required]
        [DefaultValue(100)]
        public int Gezondheid
        {
            get { return _tamagotchi.Gezondheid; }
            set
            {
                _tamagotchi.Gezondheid = value;
                if (Gezondheid > 100)
                {
                    _tamagotchi.Gezondheid = 100;
                }
                if (Gezondheid <= 0)
                {
                    _tamagotchi.Gezondheid = 0;
                    Die();
                }
            }
        }

        [Required]
        [DefaultValue(0)]
        public int Level
        {
            get { return _tamagotchi.Level; }
            set { _tamagotchi.Level = value; }
        }

        [Required]
        [DefaultValue(0)]
        public int Leeftijd
        {
            get { return _tamagotchi.Leeftijd; }
            set { _tamagotchi.Leeftijd = value; }
        }

        [Required]
        [DefaultValue(1)]
        [Range(0,1)]
        public byte Levend
        {
            get { return _tamagotchi.Levend; }
            set { _tamagotchi.Levend = value; }
        }
        
        [Required]
        [DefaultValue(0)]
        [Range(0,100)]
        public int Verveling
        {
            get { return _tamagotchi.Verveling; }
            set
            {
                _tamagotchi.Verveling = value;

                if (Verveling > 100)
                {
                    _tamagotchi.Verveling = 100;
                }

                if (Verveling >= 70)
                {
                    Gezondheid -= 20;
                }
            }
        }

        public ICollection<Hotelkamer> HotelKamers
        {
            get { return _tamagotchi.Hotelkamers; }
            set { _tamagotchi.Hotelkamers = value; }
        }

        public bool IsSelected { get; set; }

        public TamagotchiModel(Tamagotchi tamagotchi)
        {
            _tamagotchi = tamagotchi;
        }

        public TamagotchiModel()
        {
            _tamagotchi = new Tamagotchi();
        }

        public Tamagotchi ToModel()
        {
            return _tamagotchi;
        }

        public static List<string> GetAllProperties()
        {
            return new List<string>(new []
            {
                "Centjes",
                "Gezondheid",
                "Level",
                "Verveling"
            });
        }

        public Boolean HasEnoughCentjes(int value)
        {
            return (Centjes - value >= 0);
        }

        private void Die()
        {
            Levend = 0;
        }
    }
}
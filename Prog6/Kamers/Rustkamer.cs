using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Prog6.Models;
using Prog6.Respositories.Interfaces;

namespace Prog6.Kamers
{
    public class Rustkamer : IKamer
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; private set; }

        public Rustkamer()
        {
            Name = "De rustkamer";
            Price = 10;
            Description = Name + " $" + Price;
        }

        public void Nacht(List<TamagotchiModel> tamagotchi)
        {
            tamagotchi.ForEach((t) =>
            {
                Debug.WriteLine("Checking balance for " + t.Naam);
                if (t.HasEnoughCentjes(Price))
                {
                    Debug.WriteLine("Adjusting stats for " + t.Naam);
                    t.Gezondheid += 20;
                    t.Verveling += 10;
                    t.Centjes -= Price;
                    t.Leeftijd += 1;
                }
            });
        }
    }
}
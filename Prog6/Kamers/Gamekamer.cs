using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prog6.Models;

namespace Prog6.Kamers
{
    public class Gamekamer : IKamer
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; }

        public Gamekamer()
        {
            Name = "De gamekamer";
            Price = 20;
            Description = Name + " $" + Price;
        }

        public void Nacht(List<TamagotchiModel> tamagotchi)
        {
            tamagotchi.ForEach((t) =>
            {
                if (t.HasEnoughCentjes(Price))
                {
                    t.Verveling = 0;
                    t.Centjes -= Price;
                    t.Leeftijd += 1;
                    t.Level += 1;
                }
            });
        }
    }
}
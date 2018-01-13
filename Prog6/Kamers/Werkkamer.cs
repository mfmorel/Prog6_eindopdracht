using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prog6.Models;

namespace Prog6.Kamers
{
    public class Werkkamer : IKamer
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; }

        public Werkkamer()
        {
            Name = "De werkkamer";
            Price = 0;
            Description = Name + " $" + Price;
        }

        public void Nacht(List<TamagotchiModel> tamagotchi)
        {
            tamagotchi.ForEach((t) =>
            {
                if (t.HasEnoughCentjes(Price))
                {
                    t.Verveling += 20;
                    t.Centjes += new Random().Next(10, 60);
                    t.Leeftijd += 1;
                    t.Level += 1;
                }
            });
        }
    }
}
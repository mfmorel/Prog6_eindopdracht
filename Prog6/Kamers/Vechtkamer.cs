using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prog6.Models;

namespace Prog6.Kamers
{
    public class Vechtkamer : IKamer
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; }

        public Vechtkamer()
        {
            Name = "De vechtkamer";
            Price = 0;
            Description = Name + " $" + Price;
        }

        public void Nacht(List<TamagotchiModel> tamagotchi)
        {
            int rand = new Random().Next(0, (tamagotchi.Count - 1));
            tamagotchi[rand].Centjes += (20 * (tamagotchi.Count - 1));
            tamagotchi[rand].Level += 2;
            tamagotchi[rand].Leeftijd += 1;

            for (int i = 0; i < tamagotchi.Count; i++)
            {
                if(i == rand)
                    continue;

                tamagotchi[i].Gezondheid -= 30;
                tamagotchi[i].Centjes -= 20;
                tamagotchi[i].Leeftijd += 1;
                tamagotchi[i].Level += 1;
            }
        }
    }
}
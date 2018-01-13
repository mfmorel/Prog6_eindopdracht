using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prog6.Models;

namespace Prog6.Kamers
{
    public abstract class Kamer
    {
        public static List<IKamer> GetKamers()
        {
            return new List<IKamer>() {new Werkkamer(), new Vechtkamer(), new Gamekamer(), new Rustkamer()};
        }

        public static IKamer GetKamer(string kamer)
        {
            switch (kamer)
            {
                case "De rustkamer":
                    return new Rustkamer();
                case "De gamekamer":
                    return new Gamekamer();
                case "De vechtkamer":
                    return new Vechtkamer();
                case "De werkkamer":
                    return new Werkkamer();
            }

            return null;
        }
    }
}
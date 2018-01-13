using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prog6.Models;

namespace Prog6.Kamers
{
    public abstract class Kamer
    {
        public static List<String> GetKamers()
        {
            return new List<string>(new []
            {
                new Rustkamer().Name
            });
        }
    }
}
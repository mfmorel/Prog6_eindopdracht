using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog6.Models;

namespace Prog6.Kamers
{
    public interface IKamer
    {
        string Name { get; set; }
        string Description { get; set; }
        int Price { get; }
        void Nacht(List<TamagotchiModel> tamagotchi);
    }
}

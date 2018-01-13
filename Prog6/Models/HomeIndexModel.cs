using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prog6.Respositories.Interfaces;

namespace Prog6.Models
{
    public class HomeIndexModel
    {
        public List<TamagotchiModel> AllTamagotchis { get; set; }
        public List<TamagotchiModel> AliveTamagotchis { get; set; }
        public List<TamagotchiModel> DeadTamagotchis { get; set; }
        public List<TamagotchiModel> RoomlessTamagotchis { get; set; }
    }
}
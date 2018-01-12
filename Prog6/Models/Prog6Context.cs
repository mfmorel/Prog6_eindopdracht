using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Domain;

namespace Prog6.Models
{
    public class Prog6Context : DbContext
    {
        public Prog6Context() : base ("name=Prog6Entities")
        {
            
        }

        public DbSet <Tamagotchi> Tamagotchis { get; set; }
    }
}
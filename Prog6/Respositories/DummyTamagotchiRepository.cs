using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using Prog6.Models;
using Prog6.Respositories.Interfaces;

namespace Prog6.Respositories
{
    public class DummyTamagotchiRepository : ITamagotchiRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TamagotchiModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public TamagotchiModel Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<TamagotchiModel> GetAll()
        {
            return new List<TamagotchiModel>()
            {
                new TamagotchiModel() { Naam = "Henk" },
                new TamagotchiModel() { Naam = "Jan" },
                new TamagotchiModel() { Naam = "Klaas" },
                new TamagotchiModel() { Naam = "Pieter" },
                new TamagotchiModel() { Naam = "Kees" },
                new TamagotchiModel() { Naam = "Michat" },
                new TamagotchiModel() { Naam = "Bart" }
            };
        }

        public List<TamagotchiModel> GetAllAlive()
        {
            throw new NotImplementedException();
        }

        public void Create(TamagotchiModel tamagotchi)
        {
            throw new NotImplementedException();
        }

        public void Update(TamagotchiModel tamagotchi)
        {
            throw new NotImplementedException();
        }

        public void Delete(TamagotchiModel tamagotchi)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Tamagotchi Test()
        {
            throw new NotImplementedException();
        }
    }
}
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
        private List<TamagotchiModel> _tamagotchis;
        public DummyTamagotchiRepository()
        {
            _tamagotchis = new List<TamagotchiModel>()
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


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TamagotchiModel Get(int id)
        {
            if (_tamagotchis[id] != null)
                return _tamagotchis[id];

            return null;
        }

        public TamagotchiModel Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<TamagotchiModel> GetAll()
        {
            return _tamagotchis;
        }

        public List<TamagotchiModel> GetAllAlive()
        {
            throw new NotImplementedException();
        }

        public void Create(TamagotchiModel tamagotchi)
        {
            _tamagotchis.Add(tamagotchi);
        }

        public void Update(TamagotchiModel tamagotchi)
        {
            _tamagotchis[_tamagotchis.IndexOf(tamagotchi)] = tamagotchi;
        }

        public void Delete(TamagotchiModel tamagotchi)
        {
            _tamagotchis.Remove(tamagotchi);
        }

        public void Save()
        {
            return;
        }

        public Tamagotchi Test()
        {
            throw new NotImplementedException();
        }
    }
}
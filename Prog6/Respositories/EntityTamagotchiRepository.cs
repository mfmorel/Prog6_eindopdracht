using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Domain;
using Prog6.Interfaces;
using Prog6.Models;
using Prog6.Respositories.Interfaces;

namespace Prog6.Respositories
{
    public class EntityTamagotchiRepository : ITamagotchiRepository
    {
        private Prog6Context _context;

        public EntityTamagotchiRepository(Prog6Context context)
        {
            _context = context;
        }

        public Tamagotchi Test()
        {
            return _context.Tamagotchis.FirstOrDefault();
        }

        public TamagotchiModel Get(int id)
        {
            return _context.Tamagotchis.Where(t => t.Id == id).Select(t => new TamagotchiModel() {_tamagotchi = t}).FirstOrDefault();
        }

        public TamagotchiModel Get(string name)
        {
            return _context.Tamagotchis.Where(t => t.Naam.Equals(name)).Select(t => new TamagotchiModel(t)).FirstOrDefault();
        }

        public List<TamagotchiModel> GetAll()
        {
            return _context.Tamagotchis.Select((t) => new TamagotchiModel() {_tamagotchi = t}).ToList();
        }

        public void Create(TamagotchiModel tamagotchi)
        {
            _context.Tamagotchis.Add(tamagotchi.ToModel());
        }

        public void Update(TamagotchiModel tamagotchi)
        {
            _context.Entry(tamagotchi.ToModel()).State = EntityState.Modified;
        }

        public void Delete(TamagotchiModel tamagotchi)
        {
            _context.Tamagotchis.Remove(tamagotchi.ToModel());
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
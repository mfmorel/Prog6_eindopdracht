using System;
using System.Collections.Generic;
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
        private IContext _context;

        public EntityTamagotchiRepository(IContext context)
        {
            _context = context;
        }

        public TamagotchiModel Get(int id)
        {
            return _context.GetContext().Tamagotchis.Where(t => t.Id == id).Select(t => new TamagotchiModel(t)).FirstOrDefault();
        }

        public TamagotchiModel Get(string name)
        {
            return _context.GetContext().Tamagotchis.Where(t => t.Naam.Equals(name)).Select(t => new TamagotchiModel(t)).FirstOrDefault();
        }

        public List<TamagotchiModel> GetAll()
        {
            return _context.GetContext().Tamagotchis.Select(t => new TamagotchiModel(t)).ToList();
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
    }
}
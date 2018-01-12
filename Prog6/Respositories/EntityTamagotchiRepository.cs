using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prog6.Models;
using Prog6.Respositories.Interfaces;

namespace Prog6.Respositories
{
    public class EntityTamagotchiRepository : ITamagotchiRepository
    {
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
    }
}
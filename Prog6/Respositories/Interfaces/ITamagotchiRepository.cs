using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog6.Models;

namespace Prog6.Respositories.Interfaces
{
    public interface ITamagotchiRepository : IDisposable
    {
        TamagotchiModel Get(int id);
        TamagotchiModel Get(string name);
        List<TamagotchiModel> GetAll();
        List<TamagotchiModel> GetAllAlive();
        void Create(TamagotchiModel tamagotchi);
        void Update(TamagotchiModel tamagotchi);
        void Delete(TamagotchiModel tamagotchi);
        void Save();
        Domain.Tamagotchi Test();
    }
}

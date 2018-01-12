using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog6.Models;

namespace Prog6.Respositories.Interfaces
{
    public interface ITamagotchiRepository
    {
        TamagotchiModel Get(int id);
        TamagotchiModel Get(string name);
        List<TamagotchiModel> GetAll();
        void Create(TamagotchiModel tamagotchi);
        void Update(TamagotchiModel tamagotchi);
        void Delete(TamagotchiModel tamagotchi);
    }
}

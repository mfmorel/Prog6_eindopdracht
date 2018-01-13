using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prog6.Models;
using Prog6.Respositories.Interfaces;

namespace Prog6.Respositories
{
    public class EntityBoekingRepository : IBoekingRepository
    {
        public Prog6Context _context;

        public EntityBoekingRepository(Prog6Context context)
        {
            _context = context;
        }

        public BoekingModel Get(TamagotchiModel tamagotchi)
        {
            throw new NotImplementedException();
        }

        public BoekingModel Get(HotelkamerModel hotelkamer)
        {
            throw new NotImplementedException();
        }

        public List<BoekingModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<HotelkamerModel> GetAvailableRooms()
        {
            return _context.Hotelkamers.Where(h => h.Tamagotchis.Count().Equals(0))
                .Select(h => new HotelkamerModel() {_Hotelkamer = h}).ToList();
        }

        public void Create(BoekingModel tamagotchi)
        {
            throw new NotImplementedException();
        }

        public void Update(BoekingModel tamagotchi)
        {
            throw new NotImplementedException();
        }

        public void Delete(BoekingModel tamagotchi)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prog6.Models;
using Prog6.Respositories.Interfaces;

namespace Prog6.Respositories
{
    public class EntityHotelkamerTypeRepository : IHotelkamerTypeRepository
    {
        private Prog6Context _context;

        public EntityHotelkamerTypeRepository(Prog6Context context)
        {
            _context = context;
        }
        public HotelkamerTypeModel Get(string id)
        {
            throw new NotImplementedException();
        }

        public HotelkamerTypeModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<HotelkamerTypeModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(HotelkamerTypeModel tamagotchi)
        {
            throw new NotImplementedException();
        }

        public void Update(HotelkamerTypeModel tamagotchi)
        {
            throw new NotImplementedException();
        }

        public void Delete(HotelkamerTypeModel tamagotchi)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            
        }
    }
}
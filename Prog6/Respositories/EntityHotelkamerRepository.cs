using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prog6.Models;
using Prog6.Respositories.Interfaces;

namespace Prog6.Respositories
{
    public class EntityHotelkamerRepository : IHotelkamerRepository
    {
        public Prog6Context _context;

        public EntityHotelkamerRepository(Prog6Context context)
        {
            _context = context;
        }
        public HotelkamerModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public HotelkamerModel Get(string name)
        {
            throw new NotImplementedException();
        }

        public HotelkamerModel GetByGroote(int groote)
        {
            throw new NotImplementedException();
        }

        public List<HotelkamerModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(HotelkamerModel tamagotchi)
        {
            throw new NotImplementedException();
        }

        public void Update(HotelkamerModel tamagotchi)
        {
            throw new NotImplementedException();
        }

        public void Delete(HotelkamerModel tamagotchi)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
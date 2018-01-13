using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return _context.HotelkamerTypes.Where(h => h.Type.Equals(id)).Select(h => new HotelkamerTypeModel() {_hotelkamerType = h}).FirstOrDefault();
        }

        public HotelkamerTypeModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<HotelkamerTypeModel> GetAll()
        {
            return _context.HotelkamerTypes.Select(h => new HotelkamerTypeModel() {_hotelkamerType = h}).ToList();
        }

        public void Create(HotelkamerTypeModel hotelkamerType)
        {
            _context.HotelkamerTypes.Add(hotelkamerType.ToModel());
        }

        public void Update(HotelkamerTypeModel hotelkamerType)
        {
            _context.Entry(hotelkamerType.ToModel()).State = EntityState.Modified;
        }

        public void Delete(HotelkamerTypeModel hotelkamerType)
        {
            _context.HotelkamerTypes.Remove(hotelkamerType.ToModel());
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
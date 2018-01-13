using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Domain;
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
            return _context.Hotelkamers.Where(h => h.Id == id).Select(h => new HotelkamerModel() {_Hotelkamer = h}).FirstOrDefault();
        }

        public HotelkamerModel GetByGroote(int groote)
        {
            return _context.Hotelkamers.Where(h => h.Groote >= groote).Select(h => new HotelkamerModel() {_Hotelkamer = h}).FirstOrDefault();
        }

        public List<HotelkamerModel> GetAll()
        {
            return _context.Hotelkamers.Select(h => new HotelkamerModel() {_Hotelkamer = h}).ToList();
        }

        public List<HotelkamerModel> GetAllByType(HotelkamerTypeModel hotelkamerType)
        {
            return _context.Hotelkamers.Where(h => h.Type.Equals(hotelkamerType.Type)).Select(h => new HotelkamerModel() {_Hotelkamer = h}).ToList();
        }

        public void Create(HotelkamerModel hotelkamer)
        {
            _context.Hotelkamers.Add(hotelkamer.ToModel());
        }

        public void Update(HotelkamerModel hotelkamer)
        {
            _context.Entry(hotelkamer.ToModel()).State = EntityState.Modified;
        }

        public void Delete(HotelkamerModel hotelkamer)
        {
            _context.Hotelkamers.Remove(hotelkamer.ToModel());
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
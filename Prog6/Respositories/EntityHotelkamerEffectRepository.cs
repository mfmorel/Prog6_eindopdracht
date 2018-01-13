using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Prog6.Models;
using Prog6.Respositories.Interfaces;

namespace Prog6.Respositories
{
    public class EntityHotelkamerEffectRepository : IHotelkamerEffectRepository
    {
        private Prog6Context _context;

        public EntityHotelkamerEffectRepository(Prog6Context context)
        {
            _context = context;
        }

        public HotelkamerEffectModel Get(string name)
        {
            return _context.HotelkamerEffects.Where(h => h.Naam.Equals(name)).Select(h => new HotelkamerEffectModel() {_hotelkamerEffect = h}).FirstOrDefault();
        }

        public List<HotelkamerEffectModel> GetAll()
        {
            return _context.HotelkamerEffects.Select(h => new HotelkamerEffectModel() {_hotelkamerEffect = h}).ToList();
        }

        public void Create(HotelkamerEffectModel hotelkamerEffect)
        {
            _context.HotelkamerEffects.Add(hotelkamerEffect.ToModel());
        }

        public void Update(HotelkamerEffectModel hotelkamerEffect)
        {
            _context.Entry(hotelkamerEffect.ToModel()).State = EntityState.Modified;
        }

        public void Delete(HotelkamerEffectModel hotelkamerEffect)
        {
            _context.HotelkamerEffects.Remove(hotelkamerEffect.ToModel());
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
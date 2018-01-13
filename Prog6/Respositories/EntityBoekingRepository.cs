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

        public void Create(BoekingModel boeking)
        {
            Hotelkamer hk = _context.Hotelkamers.First(h => h.Id.Equals(boeking.Hotelkamer.Id));
            foreach (TamagotchiModel tamagotchiModel in boeking.Tamagotchis)
            {
                hk.Tamagotchis.Add(_context.Tamagotchis.First(t => t.Id.Equals(tamagotchiModel.Id)));
            }
            _context.Entry(hk).State = EntityState.Modified;
        }

        public BoekingModel GetByRoom(HotelkamerModel hotelkamer)
        {
            BoekingModel boekingModel = new BoekingModel();
            boekingModel.Hotelkamer = hotelkamer;
            boekingModel.Tamagotchis = boekingModel.Hotelkamer.Tamagotchis.Select(t => new TamagotchiModel() {_tamagotchi = t}).ToList();
            return boekingModel;

        }

        public void Create(BoekingModel tamagotchi)
        {
            throw new NotImplementedException();
        }

        public void Delete(BoekingModel boeking)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
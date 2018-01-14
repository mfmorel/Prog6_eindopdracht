using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prog6.Models;
using Prog6.Respositories.Interfaces;

namespace Prog6.Respositories
{
    public class DummyBoekingRepository : IBoekingRepository
    {
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
            throw new NotImplementedException();
        }

        public BoekingModel GetByRoom(HotelkamerModel hotelkamer)
        {
            throw new NotImplementedException();
        }

        public List<HotelkamerModel> GetBookedRooms()
        {
            throw new NotImplementedException();
        }

        public void Create(BoekingModel boeking)
        {
            throw new NotImplementedException();
        }

        public void Update(BoekingModel boeking)
        {
            throw new NotImplementedException();
        }

        public void Delete(BoekingModel boeking)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
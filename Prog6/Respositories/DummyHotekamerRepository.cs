using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prog6.Models;
using Prog6.Respositories.Interfaces;

namespace Prog6.Respositories
{
    public class DummyHotekamerRepository : IHotelkamerRepository
    {
        private List<HotelkamerModel> _hotelkamers;

        public DummyHotekamerRepository()
        {
            _hotelkamers = new List<HotelkamerModel>()
            {
                new HotelkamerModel()
                {
                    Id = 1,
                    Groote = 3,
                    Prijs = 10,
                    Type = "De rustkamer"
                },
                new HotelkamerModel()
                {
                    Id = 2,
                    Groote = 5,
                    Prijs = 0,
                    Type = "De vechtkamer"
                },
                new HotelkamerModel()
                {
                    Id = 3,
                    Groote = 3,
                    Prijs = 0,
                    Type = "De werkkamer"
                },
                new HotelkamerModel()
                {
                    Id = 4,
                    Groote = 5,
                    Prijs = 20,
                    Type = "De gamekamer"
                }
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public HotelkamerModel Get(int id)
        {
            if (_hotelkamers[id] != null)
                return _hotelkamers[id];

            return null;
        }

        public HotelkamerModel GetByGroote(int groote)
        {
            throw new NotImplementedException();
        }

        // TODO tamagochis toevoegen voor de reserveringen
        public List<HotelkamerModel> GetAll()
        {
            return _hotelkamers;
        }

        public List<HotelkamerModel> GetAllByType(string hotelkamerType)
        {
            throw new NotImplementedException();
        }

        public void Create(HotelkamerModel hotelkamer)
        {
            _hotelkamers.Add(hotelkamer);
        }

        public void Update(HotelkamerModel hotelkamer)
        {
            _hotelkamers[_hotelkamers.IndexOf(hotelkamer)] = hotelkamer;
        }

        public void Delete(HotelkamerModel hotelkamer)
        {
            _hotelkamers.Remove(hotelkamer);
        }

        public void Save()
        {
            return;
        }
    }
}
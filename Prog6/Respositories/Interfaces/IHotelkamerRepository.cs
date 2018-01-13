using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prog6.Models;

namespace Prog6.Respositories.Interfaces
{
    public interface IHotelkamerRepository : IDisposable
    {
        HotelkamerModel Get(int id);
        HotelkamerModel GetByGroote(int groote);
        List<HotelkamerModel> GetAll();
        List<HotelkamerModel> GetAllByType(string hotelkamerType);
        void Create(HotelkamerModel hotelkamer);
        void Update(HotelkamerModel hotelkamer);
        void Delete(HotelkamerModel hotelkamer);
        void Save();
    }
}
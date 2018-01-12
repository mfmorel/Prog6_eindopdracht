using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prog6.Models;

namespace Prog6.Respositories.Interfaces
{
    public interface IHotelkamerRepository
    {
        HotelkamerModel Get(int id);
        HotelkamerModel Get(string type);
        HotelkamerModel GetByGroote(int groote);
        List<HotelkamerModel> GetAll();
        void Create(HotelkamerModel hotelkamer);
        void Update(HotelkamerModel hotelkamer);
        void Delete(HotelkamerModel hotelkamer);
    }
}
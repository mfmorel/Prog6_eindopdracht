using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog6.Models;

namespace Prog6.Respositories.Interfaces
{
    public interface IHotelkamerTypeRepository
    {
        HotelkamerTypeModel Get(string id);
        HotelkamerTypeModel GetByName(string name);
        List<HotelkamerTypeModel> GetAll();
        void Create(HotelkamerTypeModel hotelkamerTypeModel);
        void Update(HotelkamerTypeModel hotelkamerTypeModel);
        void Delete(HotelkamerTypeModel hotelkamerTypeModel);
        void Save();
    }
}

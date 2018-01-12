using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog6.Models;

namespace Prog6.Respositories.Interfaces
{
    public interface IHotelkamerEffectRepository
    {
        HotelkamerEffectModel Get(int id);
        HotelkamerEffectModel Get(string name);
        List<HotelkamerEffectModel> GetAll();
        void Create(HotelkamerEffectModel hotelkamerEffect);
        void Update(HotelkamerEffectModel hotelkamerEffect);
        void Delete(HotelkamerEffectModel hotelkamerEffect);
    }
}

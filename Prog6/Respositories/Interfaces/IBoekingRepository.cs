using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog6.Models;

namespace Prog6.Respositories.Interfaces
{
    public interface IBoekingRepository
    {
        BoekingModel Get(TamagotchiModel tamagotchi);
        BoekingModel Get(HotelkamerModel hotelkamer);
        List<BoekingModel> GetAll();
        List<HotelkamerModel> GetAvailableRooms();
        void Create(BoekingModel boeking);
        void Update(BoekingModel boeking);
        void Delete(BoekingModel boeking);
    }
}

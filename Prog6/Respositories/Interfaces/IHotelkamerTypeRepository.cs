﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog6.Models;

namespace Prog6.Respositories.Interfaces
{
    public interface IHotelkamerTypeRepository
    {
        HotelkamerTypeModel Get(int id);
        HotelkamerTypeModel Get(string name);
        List<HotelkamerTypeModel> GetAll();
        void Create(HotelkamerTypeModel hotelkamerTypeModel);
        void Update(HotelkamerTypeModel hotelkamerTypeModel);
        void Delete(HotelkamerTypeModel hotelkamerTypeModel);
    }
}
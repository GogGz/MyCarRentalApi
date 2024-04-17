using AutoMapper;
using MyCarRentalApi.DAL.Entities;
using MyCarRentalApi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.Mappers
{
    public class CarRentalProfile : Profile
    {
        public CarRentalProfile()
        {
            CreateMap<Car, GetCarResponse>().ReverseMap();
        }



    }
    
}

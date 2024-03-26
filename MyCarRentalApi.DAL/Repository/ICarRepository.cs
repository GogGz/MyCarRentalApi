using MyCarRentalApi.DAL.Entities;
using MyCarRentalApi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.DAL.Repository
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCarsAsync();
        Task<Car?> GetCarByIdAsync(int id);
        Task AddCarAsync(AddCarRequest Entity);
        Task UpdateCarAsync(Car car);
        Task DeleteCarAsync(int id);
    }
}

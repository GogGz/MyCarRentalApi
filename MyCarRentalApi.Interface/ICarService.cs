using MyCarRentalApi.DAL.Entities;
using MyCarRentalApi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.Interface
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(int Id);
        Task InsertAsync(AddCarRequest model);
        void Update(Car Entity);
        Task DeleteAsync(int Id);

    }
}

using MyCarRentalApi.DAL.Entities;
using MyCarRentalApi.DAL.Repository;
using MyCarRentalApi.Interface;
using MyCarRentalApi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.Service
{
    public class CarService : ICarService

    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        => await  _carRepository.GetAllCarsAsync();
        public async Task<Car> GetByIdAsync(int Id)
        => await _carRepository.GetCarByIdAsync(Id);
        
        public async Task InsertAsync(AddCarRequest model)
        {
            Car car = new Car   ();

            car.Number = model.Number;
            car.Model = model.Model;
           
            await _carRepository.AddCarAsync(model);
                        
        }
        public void Update(Car Entity)
        => _carRepository.UpdateCarAsync(Entity);

        public async Task DeleteAsync(int Id)
        {
            await _carRepository.DeleteCarAsync(Id);
        }
    }
}

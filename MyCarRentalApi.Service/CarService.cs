using AutoMapper;
using Azure.Core;
using MyCarRentalApi.DAL.Concrete;
using MyCarRentalApi.DAL.Entities;
using MyCarRentalApi.DAL.Repository;
using MyCarRentalApi.Interface;
using MyCarRentalApi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.Service
{
    public class CarService : ICarService

    {
        private readonly EFGenericRepository<Car> _carRepository;

        private readonly IMapper _mapper;
        public CarService(EFGenericRepository<Car> carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            var resp = await _carRepository.GetAllAsync()

            var allCars = _mapper.Map<IEnumerable<GetCarResponse>>(resp);

          


                }

        public async Task<Car> GetByIdAsync(int Id)
        => await _carRepository.GetCarByIdAsync(Id);

        public async Task InsertAsync(AddCarRequest model)
        {
            Car car = new Car();

            car.Number = model.Number;
            car.Model = model.Model;

            await _carRepository.AddCarAsync(model);

        }
        public void Update(Car Entity)
        => _carRepository.UpdateCarAsync(Entity);

        public async Task Edit (int id, AddCarRequest model)
        {
            var carEntity = await GetByIdAsync(id);

            if (carEntity is null)
                throw new Exception();

            carEntity.Model = model.Model;
            carEntity.Number = model.Number;
            carEntity.ModifiedDate = DateTime.Now;

            Update(carEntity);
           
        }

        public async Task DeleteAsync(int Id)
        {
            await _carRepository.DeleteCarAsync(Id);
        }
    }
}

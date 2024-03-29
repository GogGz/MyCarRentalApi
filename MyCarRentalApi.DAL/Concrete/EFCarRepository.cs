using Microsoft.EntityFrameworkCore;
using MyCarRentalApi.DAL.Context;
using MyCarRentalApi.DAL.Entities;
using MyCarRentalApi.DAL.Repository;
using MyCarRentalApi.Models.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.DAL.Concrete
{
    public class EFCarRepository : ICarRepository
    {
        private readonly MyCarRentalApiDbContext _context;

        public EFCarRepository(MyCarRentalApiDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddCarAsync(AddCarRequest entity)
        {
            Car car = new Car();

            car.Number =  entity.Number;
            car.Model = entity.Model;

            await _context.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int id)
        {
            var carRemove = await _context.Cars.FindAsync(id);

            if (carRemove == null)
            {
                throw new InvalidOperationException("Car was not found");
            }

            _context.Remove(carRemove);
            await _context.SaveChangesAsync();
        }
        public async Task <IEnumerable<Car>> GetAllCarsAsync() => await _context.Cars.ToListAsync();
        
        public async Task<Car?> GetCarByIdAsync(int id)
        {
            var carGet = await _context.Cars.FindAsync(id);

            if (carGet == null)
            {
                throw new InvalidOperationException("Car id was not found");
            }

            return carGet;

        }

        public async Task UpdateCarAsync(Car car)
        {
             _context.Cars.Update(car);

            await _context.SaveChangesAsync();
        }

       
      
    }
}

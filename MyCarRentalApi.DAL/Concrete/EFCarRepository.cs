using MyCarRentalApi.DAL.Context;
using MyCarRentalApi.DAL.Entities;
using MyCarRentalApi.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.DAL.Concrete
{
    internal class EFCarRepository : ICarRepository
    {
        private readonly MyCarRentalApiDbContext _context;

        public EFCarRepository(MyCarRentalApiDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddCarAsync(Car car)
        {
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

        public IQueryable<Car> GetAllCarsAsync() => _context.Cars.AsQueryable();

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

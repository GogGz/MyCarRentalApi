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
    internal class EFCustomerRepository : ICustomerRepository
    {
        private readonly MyCarRentalApiDbContext _context;

        public EFCustomerRepository(MyCarRentalApiDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customerRemove = await _context.Customers.FindAsync(id);

            if (customerRemove == null)
            {
                throw new InvalidOperationException("Customer was not found");
            }

            _context.Remove(customerRemove);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Customer> GetAllCustomersAsync()
        {
            return _context.Customers.AsQueryable();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            var customerGet = await _context.Customers.FindAsync(id);

            if (customerGet == null)
            {
                throw new InvalidOperationException("Customer id was not found");
            }

            return customerGet;
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

    }
}

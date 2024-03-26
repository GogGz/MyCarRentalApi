using MyCarRentalApi.DAL.Entities;
using MyCarRentalApi.DAL.Models;
using MyCarRentalApi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.DAL.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(AddCustomerRequest customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}

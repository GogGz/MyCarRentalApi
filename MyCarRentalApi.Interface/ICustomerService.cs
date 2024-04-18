using MyCarRentalApi.DAL.Entities;
using MyCarRentalApi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task AddAsync(AddCustomerRequest customer);
        void Update(AddCustomerRequest customer);
        Task DeleteAsync(int id);
    }
}

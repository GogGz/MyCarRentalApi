using MyCarRentalApi.DAL.Entities;
using MyCarRentalApi.DAL.Repository;
using MyCarRentalApi.Interface;
using MyCarRentalApi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task AddCustomerAsync(AddCustomerRequest customer)
        => await _customerRepository.AddCustomerAsync(customer);
        public async Task DeleteCustomerAsync(int id)
        => await _customerRepository.DeleteCustomerAsync(id);
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        => await _customerRepository.GetAllCustomersAsync();

        public Task<Customer?> GetCustomerByIdAsync(int id)
        => _customerRepository.GetCustomerByIdAsync(id);

        public async Task UpdateCustomerAsync(Customer customer)
        {
            var existingCustomer = await _customerRepository.GetCustomerByIdAsync(customer.Id);
            if (existingCustomer == null)
            {
                throw new Exception(); 
            }

            existingCustomer.Name = customer.Name;
            existingCustomer.Surname = customer.Surname;
            existingCustomer.DrivingLicense = customer.DrivingLicense;


            await _customerRepository.UpdateCustomerAsync(customer);
        }
    }
}

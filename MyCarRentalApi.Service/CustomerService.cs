using AutoMapper;
using MyCarRentalApi.DAL.Concrete;
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
        private readonly EFGenericRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(EFGenericRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(AddCustomerRequest model)
        {
            var entity = _mapper.Map<Customer>(model);

            await _customerRepository.InsertAsync(entity);

            await _customerRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (await GetByIdAsync(id) is null)
                throw new Exception();
            await _customerRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }








        //public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        //=> await _customerRepository.GetAllAsync();




        //public async Task AddCustomerAsync(Customer customer)
        //=> await _customerRepository.InsertAsync(customer);
        //public async Task DeleteCustomerAsync(int id)
        //=> await _customerRepository.DeleteAsync(id);

        //public Task<Customer?> GetCustomerByIdAsync(int id)
        //=> _customerRepository.GetByIdAsync(id);

        //public async Task UpdateCustomerAsync(AddCustomerRequest customer)
        //{
        //    var existingCustomer = await _customerRepository.GetCustomerByIdAsync(customer.Id);
        //    if (existingCustomer == null)
        //    {
        //        throw new Exception();
        //    }

        //    existingCustomer.Name = customer.Name;
        //    existingCustomer.Surname = customer.Surname;
        //    existingCustomer.DrivingLicense = customer.DrivingLicense;


        //    await _customerRepository.UpdateCustomerAsync(existingCustomer);
        //}


    }
}

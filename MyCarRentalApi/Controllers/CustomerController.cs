using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using MyCarRentalApi.DAL.Entities;
using MyCarRentalApi.DAL.Repository;
using MyCarRentalApi.Models.Models;
using System.Runtime.InteropServices;

namespace MyCarRentalApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomersAsync();

            return Ok(customers);
        }

        [HttpGet]
        public async Task <IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);

            if(customer == null)
            {
                return BadRequest("Customer not found");
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task <IActionResult> AddCustomer(AddCustomerRequest customer)
        {
            await _customerRepository.AddCustomerAsync(customer);

            return Ok(customer);
        }

        [HttpPost]

        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            var existingCustomer = await _customerRepository.GetCustomerByIdAsync(customer.Id);
            if(existingCustomer == null)
            {
                return BadRequest("Customer not found");
            }

            existingCustomer.Name = customer.Name;
            existingCustomer.Surname = customer.Surname;
            existingCustomer.DrivingLicense = customer.DrivingLicense;

            return Ok(existingCustomer);

        }

        [HttpPost]

        public async Task <IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);

            if(customer == null)
            {
                return BadRequest("Not existed customer");
            }

            customer.IsDeleted = true;

            return Ok("Customer is removed");

        }
    }
}

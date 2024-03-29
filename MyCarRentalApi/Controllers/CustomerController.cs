using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using MyCarRentalApi.DAL.Entities;
using MyCarRentalApi.DAL.Repository;
using MyCarRentalApi.Interface;
using MyCarRentalApi.Models.Models;
using System.Runtime.InteropServices;

namespace MyCarRentalApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        public async Task< IActionResult> GetAllCustomers()
        {
            await _customerService.GetAllCustomersAsync();

            return Ok();
        }

        [HttpGet]
        public async Task <IActionResult> GetCustomerById(int id)
        {
           await _customerService.GetCustomerByIdAsync(id);

            return Ok();
        }

        [HttpPost]
        public async Task <IActionResult> AddCustomer(AddCustomerRequest customer)
        {
            await _customerService.AddCustomerAsync(customer);

            return Ok();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            await _customerService.UpdateCustomerAsync(customer);

            return Ok();
        }

        [HttpPost]

        public async Task <IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if(customer == null)
            {
                return BadRequest("Not existed customer");
            }

            customer.IsDeleted = true;

            return Ok("Customer is removed");

        }
    }
}

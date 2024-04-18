using AutoMapper;
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
       
        private readonly IMapper _mapper;


        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task< IActionResult> GetAllCustomers()
        {
            var resp = await _customerService.GetAllCustomersAsync();

            var allCustomers = _mapper.Map<IEnumerable<GetCustomerResponse>>(resp);

            return Ok(allCustomers);
        }

        [HttpGet]
        public async Task <IActionResult> GetCustomerById(int id)
        {
           var resp = await _customerService.GetCustomerByIdAsync(id);
           var getCustomer = _mapper.Map<GetCarResponse>(resp);

            return Ok(getCustomer);
        }

        [HttpPost]
        public async Task <IActionResult> AddCustomer(AddCustomerRequest customer)
        {
            await _customerService.AddCustomerAsync(customer);

            return Ok();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateCustomer(AddCustomerRequest customer)
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

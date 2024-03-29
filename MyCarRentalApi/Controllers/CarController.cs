using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCarRentalApi.DAL.Entities;
using MyCarRentalApi.DAL.Repository;
using MyCarRentalApi.Models.Models;
using MyCarRentalApi.Service;

namespace MyCarRentalApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarService _carService;

        public CarController(CarService carService)
        {
            _carService = carService;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            await _carService.GetAllAsync();

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetCarById(int id)
        {
            await _carService.GetByIdAsync(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCarRequest entity)
        {
            await _carService.InsertAsync(entity);
            return Ok();
           
        }


        [HttpPost("{id}")]
        public  IActionResult EditCar(Car car)
        {
          _carService.Update(car);
               
            return Ok(car);
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carService.DeleteAsync(id);

            return Ok();
        }

    }
}

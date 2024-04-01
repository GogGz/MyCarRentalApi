using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCarRentalApi.DAL.Entities;
using MyCarRentalApi.DAL.Repository;
using MyCarRentalApi.Interface;
using MyCarRentalApi.Models.Models;
using MyCarRentalApi.Service;

namespace MyCarRentalApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        private readonly IMapper _mapper;

        public CarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
            
        }

      //  private List<Car> listCars = new List<Car>();

      [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var resp = await _carService.GetAllAsync();

            var allCars = _mapper.Map<GetAllCarsResponse>(resp.FirstOrDefault());

            return Ok(allCars);
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

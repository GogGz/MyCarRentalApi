using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCarRentalApi.DAL.Entities;
using MyCarRentalApi.DAL.Repository;

namespace MyCarRentalApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        //private static List<Car> _cars = new List<Car>
        //{
        //    new Car { Id = 1, Model = "BMW", Price = 10000.00m, Number = "AS1234" },
        //    new Car { Id = 2, Model = "Mercedes", Price = 2000.00m, Number = "DG9876" },
        //    new Car { Id = 3, Model = "Audi", Price = 3000.00m, Number = "GY8765"},
        //};

        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _carRepository.GetAllCarsAsync().ToList();

            return Ok(cars);
        }

        [HttpGet]
        public IActionResult Add()
        {
            Car car = new Car();
            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Car car)
        {

            if (ModelState.IsValid)
            {
                await _carRepository.AddCarAsync(car);

                return RedirectToAction(nameof(Index));
            }

            return Ok(car);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetCar(int id)
        {
            var car = _carRepository.GetCarByIdAsync(id);

            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> EditCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            var existingCar = _carRepository.GetCarByIdAsync(id);

            if (existingCar == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                await _carRepository.UpdateCarAsync(car);

                return RedirectToAction(nameof(GetCars));
            }
            return Ok(car);
        }



        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = _carRepository.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            await _carRepository.DeleteCarAsync(id);

            return Ok();
        }

    }
}

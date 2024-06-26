﻿using AutoMapper;
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

        public CarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;


        }

        //  private List<Car> listCars = new List<Car>();

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var resp = await _carService.GetAllAsync();

            return Ok(resp);
        }

        [HttpGet]
        public async Task<IActionResult> GetCarById(int id)
        {
            var resp = await _carService.GetByIdAsync(id);

            var getCar = _mapper.Map<GetCarResponse>(resp);

            return Ok(getCar);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCarRequest entity)
        {
            await _carService.InsertAsync(entity);
            return Ok();

        }


        [HttpPost("{id}")]
        public async Task<IActionResult> EditCar(int id, AddCarRequest request)
        {
            var carEntity = await _carService.GetByIdAsync(id);

            if (carEntity is null)
                return BadRequest("Not found");
            carEntity.Model = request.Model;
            carEntity.Number = request.Number;
            carEntity.ModifiedDate = DateTime.Now;

            _carService.Update(carEntity);


            return Ok(carEntity);
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car is null)
                return NotFound("missing car");
            car.IsDeleted = true;

            return Ok();
        }

    }
}

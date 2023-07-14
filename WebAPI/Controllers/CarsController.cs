
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getbybrands")]
        public IActionResult GetByBrands(int id)
        {
            var result = _carService.GetCarsByBrands(id);
            if(result.Success)
                return Ok(result);
            return BadRequest(result);

        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAllCars();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getbycolors")]
        public IActionResult GetByColors(int id)
        {
            var result = _carService.GetCarsByColor(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetCarById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getbydailyprice")]
        public IActionResult GetByDailyPrice(int min,int max)
        {
            var result = _carService.GetCarsByDailyPrice(min,max);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getbymodelyears")]
        public IActionResult GetByModelYears(string year)
        {
            var result = _carService.GetCarsByModelYear(year);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getcardto")]
        public IActionResult GetCarDto()
        {
            var result = _carService.GetCarsDetail();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("deletecar")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.DeleteCar(car);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("updatecar")]
        public IActionResult Update(Car car)
        {
            var result = _carService.UpdateCar(car);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.AddCar(car);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}

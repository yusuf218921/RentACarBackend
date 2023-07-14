using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getnotreturn")]
        public IActionResult GetNotReturn()
        {
            var result = _rentalService.GetNotReturnCars();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getreturned")]
        public IActionResult GetReturned()
        {
            var result = _rentalService.GetOnlyReturnCars();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.Get(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody] Rental rental, [FromQuery] Car car)
        {
            var result = _rentalService.Add(rental,car);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

    }
}

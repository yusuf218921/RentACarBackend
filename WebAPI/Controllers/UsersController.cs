using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("getclaims")]
        public IActionResult GetClaims(int id) 
        {
            var result = _userService.GetClaims(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

    }
}

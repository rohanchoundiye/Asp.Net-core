using Microsoft.AspNetCore.Mvc;
using SqlRepository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthenticationRepository _authRepository;
        public AuthController(IAuthenticationRepository authRepository)
        {
            _authRepository = authRepository;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegister userDetails)
        {
            var result = await _authRepository.Register(userDetails);
            return Ok(result);
        }

        [HttpPost]
        [Route("AdminRegister")]
        public async Task<IActionResult> AdminRegister([FromBody] UserRegister userDetails)
        {
            var result = await _authRepository.AdminRegister(userDetails);
            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLoginDetails)
        {
            var result = await _authRepository.Login(userLoginDetails);
            return Ok(result);
        }


    }
}

using Application.DataTransferObjects.AuthDtos;
using Application.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/auth/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDto userForRegistration)
        {
            var res = await _service.AuthService.RegisterUser(userForRegistration);
            if (!res.Item1.Succeeded)
            {
                foreach (var error in res.Item1.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok(res.Item2); // should fix it to return 201 instead of 200
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto userForAuth)
        {
            if (!await _service.AuthService.ValidateUser(userForAuth))
                return Unauthorized();
            var tokenDto = await _service.AuthService.CreateToken(populateExpiry: true);
            return Ok(tokenDto);
        }
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _service.AuthService.GetStaffsAsync());
        }
        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _service.AuthService.GetRolesAsync());
        }
    }
}

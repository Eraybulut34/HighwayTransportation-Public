using System.Threading.Tasks;
using HighwayTransportation.Core.Dtos;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Providers;
using Microsoft.AspNetCore.Mvc;

namespace HighwayTransportation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly AppUserProvider _appUserProvider;

        public AppUserController(AppUserProvider appUserProvider)
        {
            _appUserProvider = appUserProvider;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpRequest signUpRequest)
        {
            var response = await _appUserProvider.SignUp(signUpRequest);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var response = await _appUserProvider.Login(loginRequest);
            return Ok(response);
        }
    }
}

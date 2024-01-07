using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HighwayTransportation.Core.Dtos;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Providers;
using HighwayTransportation.Services;
using Microsoft.AspNetCore.Mvc;

namespace HighwayTransportation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IGenericService<AppUser> _appUserService;
        private readonly AppUserProvider _appUserProvider;

        public AppUserController(AppUserService appUserService, AppUserProvider appUserProvider)
        {
            _appUserService = appUserService;
            _appUserProvider = appUserProvider;
        }

        [HttpPost]
        public async Task<ActionResult<AppUser>> PostAppUser(AppUser appUser)
        {
            await _appUserService.AddAsync(appUser);

            return CreatedAtAction(nameof(AppUser), new { id = appUser.Id }, appUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser(int id, AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return BadRequest();
            }

            await _appUserService.UpdateAsync(appUser);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            var appUser = await _appUserService.GetByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            await _appUserService.RemoveAsync(appUser);

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var response = await _appUserProvider.Login(loginRequest);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}

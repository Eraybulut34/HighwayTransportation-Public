using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Services;
using Microsoft.AspNetCore.Mvc;
using HighwayTransportation.Providers;
using Microsoft.OpenApi.Any;
using HighwayTransportation.Core;
using HighwayTransportation.Core.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace HighwayTransportation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehicleController : ControllerBase
    {

        private readonly VehicleProvider _vehicleProvider;

        public VehicleController(VehicleProvider vehicleProvider)
        {
            _vehicleProvider = vehicleProvider;
        }

        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<List<GetVehicleListDto>>> GetVehicles()
        {
            var vehicles = await _vehicleProvider.GetVehicles();
            return Ok(vehicles);
        }

        [HttpPost]
        public async Task<ActionResult<Vehicle>> CreateVehicle(CreateVehicleDto vehicle)
        {
            var createdVehicle = await _vehicleProvider.CreateVehicle(vehicle);
            return CreatedAtAction(nameof(GetVehicles), new { id = createdVehicle.Id }, createdVehicle);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetVehicleDetailDto>> GetVehicle(int id)
        {
            var vehicle = await _vehicleProvider.GetVehicleDetail(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, UpdateVehicleDto vehicle)
        {
            var vehicleEntity = await _vehicleProvider.UpdateVehicle(id, vehicle);
            return Ok(vehicleEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            await _vehicleProvider.DeleteVehicle(id);
            return Ok();
        }
    }
}

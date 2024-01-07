using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Services;
using Microsoft.AspNetCore.Mvc;

namespace HighwayTransportation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IGenericService<Delivery> _deliveryService;

        public DeliveryController(IGenericService<Delivery> deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Delivery>>> GetDeliveries()
        {
            var deliveries = await _deliveryService.GetAllAsync();
            return Ok(deliveries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Delivery>> GetDelivery(int id)
        {
            var delivery = await _deliveryService.GetByIdAsync(id);

            if (delivery == null)
            {
                return NotFound();
            }

            return Ok(delivery);
        }

        [HttpPost]
        public async Task<ActionResult<Delivery>> CreateDelivery(Delivery delivery)
        {
            await _deliveryService.AddAsync(delivery);
            return CreatedAtAction(nameof(GetDelivery), new { id = delivery.Id }, delivery);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDelivery(int id, Delivery delivery)
        {
            if (id != delivery.Id)
            {
                return BadRequest();
            }

            await _deliveryService.UpdateAsync(delivery);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            var delivery = await _deliveryService.GetByIdAsync(id);

            if (delivery == null)
            {
                return NotFound();
            }

            await _deliveryService.RemoveAsync(delivery);

            return NoContent();
        }
    }
}

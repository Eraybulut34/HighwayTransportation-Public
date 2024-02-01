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

    public class DeliveryController : ControllerBase
    {

        private readonly DeliveryProvider _deliveryProvider;

        public DeliveryController(DeliveryProvider deliveryProvider)
        {
            _deliveryProvider = deliveryProvider;
        }

        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<List<GetDeliveryListDto>>> GetDeliverys()
        {
            var deliverys = await _deliveryProvider.GetDeliverys();
            return Ok(deliverys);
        }

        [HttpPost]
        public async Task<ActionResult<Delivery>> CreateDelivery(CreateDeliveryDto delivery)
        {
            var createdDelivery = await _deliveryProvider.CreateDelivery(delivery);
            return CreatedAtAction(nameof(GetDeliverys), new { id = createdDelivery.Id }, createdDelivery);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetDeliveryDetailDto>> GetDelivery(int id)
        {
            var delivery = await _deliveryProvider.GetDeliveryDetail(id);

            if (delivery == null)
            {
                return NotFound();
            }

            return Ok(delivery);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDelivery(int id, UpdateDeliveryDto delivery)
        {
            var deliveryEntity = await _deliveryProvider.UpdateDelivery(id, delivery);
            return Ok(deliveryEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            await _deliveryProvider.DeleteDelivery(id);
            return Ok();
        }
    }
}

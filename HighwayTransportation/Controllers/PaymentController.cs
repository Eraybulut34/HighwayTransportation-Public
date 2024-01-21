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

namespace HighwayTransportation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly PaymentProvider _paymentProvider;

        public PaymentController(PaymentProvider paymentProvider)
        {
            _paymentProvider = paymentProvider;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetPaymentListDto>>> GetPayments()
        {
            var payments = await _paymentProvider.GetPayments();
            return Ok(payments);
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> CreatePayment(CreatePaymentDto payment)
        {
            var createdPayment = await _paymentProvider.CreatePayment(payment);
            return CreatedAtAction(nameof(GetPayments), new { id = createdPayment.Id }, createdPayment);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPaymentDetailDto>> GetPayment(int id)
        {
            var payment = await _paymentProvider.GetPaymentDetail(id);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, UpdatePaymentDto payment)
        {
            var paymentEntity = await _paymentProvider.UpdatePayment(id, payment);
            return Ok(paymentEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            await _paymentProvider.DeletePayment(id);
            return Ok();
        }
    }
}

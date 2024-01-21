using System.Collections.Generic;
using System.Linq;
using MapsterMapper;
using HighwayTransportation.Providers;
using HighwayTransportation.Services;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Core;
using HighwayTransportation.Core.Dtos;


namespace HighwayTransportation.Providers
{
    public class PaymentProvider : ProviderBase<PaymentService, Payment>
    {
        IMapper _mapper;
        PaymentService _paymentService;

        public PaymentProvider(PaymentService paymentService, IMapper mapper) : base(paymentService)
        {
            _mapper = mapper;
            _paymentService = paymentService;
        }

        public async Task<List<GetPaymentListDto>> GetPayments()
        {
            //IsDeleted == false
            var payments = await _paymentService.GetAllAsync();
            return _mapper.Map<List<GetPaymentListDto>>(payments.Where(x => x.IsDeleted == false).ToList());
        }

        public async Task<Payment> CreatePayment(CreatePaymentDto payment)
        {
            var paymentEntity = _mapper.Map<Payment>(payment);
            await _paymentService.AddAsync(paymentEntity);
            return paymentEntity;
            
        }

        public async Task<GetPaymentDetailDto> GetPaymentDetail(int id)
        {
            var payment = await _paymentService.GetByIdAsync(id);
            if (payment == null || payment.IsDeleted == true)
            {
                return null;
            }
            return _mapper.Map<GetPaymentDetailDto>(payment);
        }

        public async Task<GetPaymentDetailDto> UpdatePayment(int id, UpdatePaymentDto payment)
        {
            var paymentEntity = _paymentService.GetByIdAsync(id).Result;
            paymentEntity.Amount = payment.Amount;
            paymentEntity.PaymentDate = payment.PaymentDate;
            paymentEntity.PaymentType = payment.PaymentType;
            paymentEntity.Description = payment.Description;
            paymentEntity.PaymentMethod = payment.PaymentMethod;
            paymentEntity.PaymentType = payment.PaymentType;
            await _paymentService.UpdateAsync(paymentEntity);
            return _mapper.Map<GetPaymentDetailDto>(paymentEntity);
        }

        public async Task DeletePayment(int id)
        {
            var paymentEntity = _paymentService.GetByIdAsync(id).Result;
            paymentEntity.IsDeleted = true;
            await _paymentService.UpdateAsync(paymentEntity);
        }
    }
}
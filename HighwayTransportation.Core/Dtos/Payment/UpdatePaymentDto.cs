using HighwayTransportation.Domain.Enums;
using HighwayTransportation.Domain.Entities;

namespace HighwayTransportation.Core.Dtos
{
    public class UpdatePaymentDto
    {

        public int Amount { get; set; }

        public string? Description { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentMethodEnum PaymentMethod { get; set; }

        public PaymentTypeEnum PaymentType { get; set; }


    }
}
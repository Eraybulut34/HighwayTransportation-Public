using HighwayTransportation.Domain.Enums;
using HighwayTransportation.Domain.Entities;

namespace HighwayTransportation.Core.Dtos
{
    public class CreatePaymentDto
    {

        public string? Amount { get; set; }

        public string? Description { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentMethodEnum PaymentMethod { get; set; }

        public int CompanyId { get; set; }

    }
}
using HighwayTransportation.Domain;
using Microsoft.EntityFrameworkCore;
using HighwayTransportation.Domain.Entities;

namespace HighwayTransportation.Services
{
    public class PaymentService : GenericService<Payment>
    {
        public PaymentService(AppDbContext context) : base(context)
        {
        }
    }
}

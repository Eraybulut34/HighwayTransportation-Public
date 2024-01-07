using HighwayTransportation.Domain;
using Microsoft.EntityFrameworkCore;
using HighwayTransportation.Domain.Entities;

namespace HighwayTransportation.Services
{
    public class DeliveryService : GenericService<Delivery>
    {
        public DeliveryService(AppDbContext context) : base(context)
        {
        }
    }
}

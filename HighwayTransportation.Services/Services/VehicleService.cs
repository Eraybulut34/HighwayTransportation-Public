using HighwayTransportation.Domain;
using Microsoft.EntityFrameworkCore;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Services;

namespace HighwayTransportation.Services
{
    public class VehicleService : GenericService<Vehicle>
    {
        public VehicleService(AppDbContext context) : base(context)
        {
        }
    }
}

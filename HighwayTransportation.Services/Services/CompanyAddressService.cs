using HighwayTransportation.Domain;
using Microsoft.EntityFrameworkCore;
using HighwayTransportation.Domain.Entities;

namespace HighwayTransportation.Services
{
    public class CompanyAddressService : GenericService<CompanyAddress>
    {
        public CompanyAddressService(AppDbContext context) : base(context)
        {
        }
    }
}

using HighwayTransportation.Domain;
using Microsoft.EntityFrameworkCore;
using HighwayTransportation.Domain.Entities;

namespace HighwayTransportation.Services
{
    public class CompanyService : GenericService<Company>
    {
        public CompanyService(AppDbContext context) : base(context)
        {
        }
    }
}

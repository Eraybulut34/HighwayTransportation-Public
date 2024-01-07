using HighwayTransportation.Domain;
using Microsoft.EntityFrameworkCore;
using HighwayTransportation.Domain.Entities;

namespace HighwayTransportation.Services
{
    public class AppUserService : GenericService<AppUser>
    {
        public AppUserService(AppDbContext context) : base(context)
        {
        }
    }
}

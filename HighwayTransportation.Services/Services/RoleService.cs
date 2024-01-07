using HighwayTransportation.Domain;
using Microsoft.EntityFrameworkCore;
using HighwayTransportation.Domain.Entities;

namespace HighwayTransportation.Services
{
    public class RoleService : GenericService<Role>
    {
        public RoleService(AppDbContext context) : base(context)
        {
        }
    }
}

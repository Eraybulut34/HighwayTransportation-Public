using HighwayTransportation.Domain;
using Microsoft.EntityFrameworkCore;
using HighwayTransportation.Domain.Entities;

namespace HighwayTransportation.Services
{
    public class ProjectService : GenericService<Project>
    {
        public ProjectService(AppDbContext context) : base(context)
        {
        }
    }
}

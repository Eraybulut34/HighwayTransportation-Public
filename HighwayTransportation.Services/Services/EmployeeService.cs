using HighwayTransportation.Domain;
using Microsoft.EntityFrameworkCore;
using HighwayTransportation.Domain.Entities;

namespace HighwayTransportation.Services
{
    public class EmployeeService : GenericService<Employee>
    {
        public EmployeeService(AppDbContext context) : base(context)
        {
        }
    }
}

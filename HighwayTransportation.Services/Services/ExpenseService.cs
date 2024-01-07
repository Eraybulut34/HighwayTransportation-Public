using HighwayTransportation.Domain;
using Microsoft.EntityFrameworkCore;
using HighwayTransportation.Domain.Entities;

namespace HighwayTransportation.Services
{
    public class ExpenseService : GenericService<Expense>
    {
        public ExpenseService(AppDbContext context) : base(context)
        {
        }
    }
}

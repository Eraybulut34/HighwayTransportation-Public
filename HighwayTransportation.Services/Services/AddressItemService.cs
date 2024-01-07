using HighwayTransportation.Domain;
using Microsoft.EntityFrameworkCore;
using HighwayTransportation.Domain.Entities;

namespace HighwayTransportation.Services
{
    public class AddressItemService : GenericService<AddressItem>
    {
        public AddressItemService(AppDbContext context) : base(context)
        {
        }
    }
}

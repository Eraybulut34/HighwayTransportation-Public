using HighwayTransportation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Entities
{
    public class CompanyAddress : BaseEntity
    {
        public CompanyAddress()
        {
            Name = "";
            District = new AddressItem();
            City = new AddressItem();
            Country = new AddressItem();
            Address = "";
        }
        public string Name { get; set; }

        public AddressItem District { get; set; }

        public AddressItem City { get; set; }

        public AddressItem Country { get; set; }

        public string Address { get; set; }
    }
}

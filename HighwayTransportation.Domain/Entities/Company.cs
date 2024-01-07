using HighwayTransportation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string? Name { get; set; }
        public string? TaxNumber { get; set; }

        public List<CompanyAddress>? Addresses { get; set; }

        public List<Vehicle>? Vehicles { get; set; }

        public List<Employee>? Drivers { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public List<string>? WebSites { get; set; }


    }
}

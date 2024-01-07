using HighwayTransportation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Entities
{
    public class Vehicle : IEntity
    {
        public string? Name { get; set; }
        public string? Plate { get; set; }
        public string? LicenseNumber { get; set; }
        public int ModelYear { get; set; }
        public DateTime TraficLicenseDate { get; set; }
        public List<Employee>? Drivers { get; set; }

        public Company? Company { get; set; }

    }
}

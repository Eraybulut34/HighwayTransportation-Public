using HighwayTransportation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Entities
{
    public class Company : IEntity
    {

        public string Name { get; set; } = string.Empty;
        public string TaxNumber { get; set; } = string.Empty;

        public List<CompanyAddress> Addresses { get; set; } = new List<CompanyAddress>();

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public List<string> WebSites { get; set; } = new List<string>();


    }
}

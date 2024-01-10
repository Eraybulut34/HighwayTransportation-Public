using HighwayTransportation.Domain.Common;
using HighwayTransportation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Entities
{
    public class Project : IEntity
    {

        public Project()
        {
            Name = "";
            Description = "";
            Payments = new List<Payment>();
            ProjectEmployees = new List<Employee>();
            ProjectAddresses = new List<CompanyAddress>();
            Vehicles = new List<Vehicle>();
            Company = new Company();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ProjectStatusEnum ProjectStatus { get; set; }

        public Company Company { get; set; }

        public List<Payment> Payments { get; set; }

        public List<Employee> ProjectEmployees { get; set; }

        public List<CompanyAddress> ProjectAddresses { get; set; }

        public List<Vehicle> Vehicles { get; set; }

    }
}

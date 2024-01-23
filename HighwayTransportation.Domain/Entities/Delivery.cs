using HighwayTransportation.Domain.Common;
using HighwayTransportation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Entities
{
    public class Delivery : IEntity
    {
        public Delivery()
        {
            CompanyAddress = new CompanyAddress();
            Company = new Company();
            Vehicle = new Vehicle();
            Employee = new Employee();
            DeliveryDate = DateTime.Now;
            DeliveryTime = DateTime.Now;
            DeliveryTimeEnd = DateTime.Now;
            DeliveryNote = "";
            DeliveryNumber = "";
            DocumentNumber = "";
            DeliveryType = DeliveryTypeEnum.Unknown;
            Project = new Project();
        }
        public CompanyAddress CompanyAddress { get; set; }

        public Company Company { get; set; }

        public Vehicle Vehicle { get; set; }

        public Employee Employee { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime DeliveryTime { get; set; }

        public DateTime DeliveryTimeEnd { get; set; }

        public string DeliveryNote { get; set; }

        public string DeliveryNumber { get; set; }

        public string DocumentNumber { get; set; }

        public DeliveryTypeEnum DeliveryType { get; set; }

        public Project Project { get; set; }

    }
}

using HighwayTransportation.Domain.Common;
using HighwayTransportation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Payment()
        {
            Description = "";
            Amount = 0;
            PaymentDate = DateTime.Now;
            PaymentMethod = PaymentMethodEnum.Cash;
            Company = new Company();
            Project = new Project();
            PaymentStatus = PaymentStatusEnum.Paid;
        }

        public string Description { get; set; }

        public int Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentMethodEnum PaymentMethod { get; set; }

        public Company Company { get; set; }

        public Project Project { get; set; }

        public PaymentStatusEnum PaymentStatus { get; set; }

    }
}

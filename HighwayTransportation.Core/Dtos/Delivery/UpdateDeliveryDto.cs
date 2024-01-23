using HighwayTransportation.Domain.Common;
using HighwayTransportation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Entities
{
    public class UpdateDeliveryDto
    {
        public int CompanyAddressId { get; set; }

        public int CompanyId { get; set; }

        public int VehicleId { get; set; }

        public int DriverId { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime DeliveryTime { get; set; }

        public DateTime DeliveryTimeEnd { get; set; }

        public string DeliveryNote { get; set; }

        public string DeliveryNumber { get; set; }

        public string DocumentNumber { get; set; }

        public DeliveryTypeEnum DeliveryType { get; set; }

        public int ProjectId { get; set; }

    }
}

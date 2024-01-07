using HighwayTransportation.Domain.Common;
using HighwayTransportation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Entities
{
    public class AddressItem : BaseEntity
    {
        public string? Name { get; set; }

        public AddressItemTypeEnum AddressItemType { get; set; }

        public AddressItem? Parent { get; set; }
    }
}

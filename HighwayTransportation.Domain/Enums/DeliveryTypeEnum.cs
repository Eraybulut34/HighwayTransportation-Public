using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Enums
{
    public enum DeliveryTypeEnum
    {
        Unknown,  // Bilinmeyen
        Standard, // Standart Teslimat
        Express,  // Express Teslimat
        SameDay,  // Aynı Gün Teslimat
        Overnight // Gece Teslimat
    }
}

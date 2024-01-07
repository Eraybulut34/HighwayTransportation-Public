using HighwayTransportation.Domain.Common;
using HighwayTransportation.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Entities
{
    public class Role : IdentityRole<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

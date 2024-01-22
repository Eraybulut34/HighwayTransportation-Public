using HighwayTransportation.Domain.Common;
using System;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Core.Dtos

{
    public class GetCompanyDetailDto
    {
        public string Name { get; set; }
        public string TaxNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public List<string> WebSites { get; set; }

    }
}

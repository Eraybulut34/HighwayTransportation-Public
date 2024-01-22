using HighwayTransportation.Domain.Common;
using System;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Core.Dtos

{
    public class CreateCompanyDto
    {
        public string Name { get; set; }
        public string TaxNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }


    }
}

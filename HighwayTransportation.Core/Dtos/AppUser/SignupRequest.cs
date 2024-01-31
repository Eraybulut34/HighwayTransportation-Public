using HighwayTransportation.Domain.Common;
using System;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Core.Dtos

{
    public class SignUpRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }


    }
}

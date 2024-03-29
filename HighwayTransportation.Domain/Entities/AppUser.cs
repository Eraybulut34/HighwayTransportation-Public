﻿using HighwayTransportation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Entities
{
    public class AppUser : IEntity
    {
        public AppUser()
        {
            Name = "";
            Surname = "";
            Email = "";
            PhoneNumber = "";
            Password = "";
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public string Role { get; set; } = "";
    }
}

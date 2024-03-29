﻿using HighwayTransportation.Domain.Common;
using HighwayTransportation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Entities
{
    public class Employee : IEntity
    {
        public Employee(){
            Name = "";
            SurName = "";
            Vehicles = new List<Vehicle>();
            BloodGroup = BloodGroupEnum.ONegative;
            LicenseTypes = new List<DriverLicenseTypesEnum>();
            Addresses = new List<AddressItem>();
            IdentityNumber = "";
            PhoneNumber = "";
            Email = "";
            StartDate = DateTime.UtcNow;
            EndDate = DateTime.UtcNow;
        }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<DriverLicenseTypesEnum> LicenseTypes { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public BloodGroupEnum BloodGroup { get; set; }


        public GenderEnum Gender { get; set; }

        public WorkingTypeEnum WorkingType { get; set; }

        public string IdentityNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        //işe başlama tarihi
        //işten ayrılma tarihi
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<AddressItem> Addresses { get; set; }

        public EmployeeTypeEnum EmployeeType { get; set; }  


    }
}

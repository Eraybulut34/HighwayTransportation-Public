﻿using HighwayTransportation.Domain.Common;
using HighwayTransportation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Core.Dtos
{
    public class GetEmployeeListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<DriverLicenseTypesEnum> LicenseTypes { get; set; }
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

        public EmployeeTypeEnum EmployeeType { get; set; }  


    }
}

using HighwayTransportation.Domain.Common;
using HighwayTransportation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayTransportation.Core.Dtos;

namespace HighwayTransportation.Core.Dtos
{
    public class GetExpenseListDto
    {
        public string Description { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }

        public GetEmployeeListDto Employee { get; set; }

        public GetCompanyListDto Company { get; set; }

        public GetProjectListDto Project { get; set; }

        public GetVehicleListDto Vehicle { get; set; }

        public ExpenseTypeEnum Type { get; set; }

    }
}

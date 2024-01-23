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
    public class CreateExpenseDto
    {
        public string Description { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }

        public int EmployeeId { get; set; }

        public int CompanyId { get; set; }

        public int ProjectId { get; set; }

        public int VehicleId { get; set; }

        public ExpenseTypeEnum Type { get; set; }

    }
}

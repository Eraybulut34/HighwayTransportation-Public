using HighwayTransportation.Domain.Common;
using HighwayTransportation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Entities
{
    public class Expense : IEntity
    {

        public string Description { get; set; } = string.Empty;

        public int Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public Employee Employee { get; set; } = new ();

        public int EmployeeId { get; set; }

        public Vehicle Vehicle { get; set; } = new ();

        public int VehicleId { get; set; }

        public Company Company { get; set; } = new ();

        public int CompanyId { get; set; }

        public Project Project { get; set; } = new ();

        public int ProjectId { get; set; }

        public ExpenseTypeEnum Type { get; set; } = ExpenseTypeEnum.Fuel;

    }
}

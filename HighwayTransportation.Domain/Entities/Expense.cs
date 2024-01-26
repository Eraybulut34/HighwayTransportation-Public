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
        public Expense()
        {
            Description = "";
            Amount = 0;
            Date = DateTime.UtcNow;
            Employee = new Employee();
            EmployeeId = 0;
            Vehicle = new Vehicle();
            VehicleId = 0;
            Company = new Company();
            CompanyId = 0;
            Project = new Project();
            ProjectId = 0;
            Type = ExpenseTypeEnum.Fuel;
        }

        public string Description { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }

        public Employee Employee { get; set; }

        public int EmployeeId { get; set; }

        public Vehicle Vehicle { get; set; }

        public int VehicleId { get; set; }

        public Company Company { get; set; }

        public int CompanyId { get; set; }

        public Project Project { get; set; }

        public int ProjectId { get; set; }

        public ExpenseTypeEnum Type { get; set; }

    }
}

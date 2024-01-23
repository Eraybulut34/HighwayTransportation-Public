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
            Date = DateTime.Now;
            Employee = new Employee();
            Vehicle = new Vehicle();
            Company = new Company();
            Project = new Project();
            Type = ExpenseTypeEnum.Fuel;
        }

        public string Description { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }

        public Employee Employee { get; set; }

        public Vehicle Vehicle { get; set; }

        public Company Company { get; set; }

        public Project Project { get; set; }

        public ExpenseTypeEnum Type { get; set; }

    }
}

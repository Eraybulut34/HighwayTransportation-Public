using HighwayTransportation.Domain.Common;
using HighwayTransportation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Entities
{
    public class Expense : BaseEntity
    {

        public string? Description { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }

        public Employee? Driver { get; set; }

        public Vehicle? Vehicle { get; set; }

        public Company? Company { get; set; }

        public Project? Project { get; set; }

        public ExpenseTypeEnum Type { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Zip.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public int Index { get; set; }
        public string Email { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal MonthlyExpenses { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public Account Account { get; set; }
    }
}

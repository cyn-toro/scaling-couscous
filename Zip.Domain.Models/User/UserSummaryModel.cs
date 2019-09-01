using System;
using System.Collections.Generic;
using System.Text;

namespace Zip.Domain.Models.User
{
    public class UserSummaryModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal MonthlyExpenses { get; set; }
    }
}

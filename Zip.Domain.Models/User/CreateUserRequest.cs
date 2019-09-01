using System.ComponentModel.DataAnnotations;

namespace Zip.Domain.Models.User
{
    public class CreateUserRequest
    {
        [EmailAddress]
        public string Email { get; set; }

        [Range(1.0, double.MaxValue)]
        public decimal MonthlySalary { get; set; }

        [Range(1.0, double.MaxValue)]
        public decimal MonthlyExpenses { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Zip.Domain.Models.User
{
    public class UserAccountModel
    {
        public Guid Id { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal AvailableCredit { get; set; }
    }
}

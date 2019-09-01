using System;
using System.Collections.Generic;
using System.Text;

namespace Zip.Data.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public int Index { get; set; }
        public Guid UserId { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal CreditBalance { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public User User { get; set; }
    }
}

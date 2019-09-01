using System;
using Zip.Domain.Models.User;

namespace Zip.Domain.Models.Account
{
    public class AccountModel : UserAccountModel
    {
        public Guid UserId { get; set; }
    }
}

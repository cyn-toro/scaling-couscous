using System;
using MediatR;
using Zip.Domain.Models.Account;
using Zip.Domain.Models.User;

namespace Zip.Domain.User.Commands
{
    public class CreateUserAccountCommand : IRequest<UserDetailsModel>
    {
        public CreateUserAccountCommand(Guid userId, CreateAccountRequest request)
        {
            UserId = userId;
            Request = request;
        }

        public Guid UserId { get; }
        public CreateAccountRequest Request { get; }
    }
}

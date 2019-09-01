using System;
using MediatR;
using Zip.Domain.Models.User;

namespace Zip.Domain.User.Commands
{
    public class CreateUserCommand : IRequest<UserSummaryModel>
    {
        public CreateUserCommand(Guid id, CreateUserRequest request)
        {
            Id = id;
            Request = request;
        }

        public Guid Id { get; }
        public CreateUserRequest Request { get; }
    }
}

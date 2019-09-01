using System;
using MediatR;
using Zip.Domain.Models.User;

namespace Zip.Domain.User.Queries
{
    public class GetUserQuery : IRequest<UserDetailsModel>
    {
        public GetUserQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

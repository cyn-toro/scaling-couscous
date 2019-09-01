using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zip.Domain.Models.User;
using Zip.Domain.User.Queries;

namespace Zip.Data.Units.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDetailsModel>
    {
        private readonly ZipDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(ZipDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDetailsModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .Include(x => x.Account)
                .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

            if (user == null)
                return null;

            var mappedUser = _mapper.Map<UserDetailsModel>(user);
            if (user.Account != null)
                mappedUser.Account = _mapper.Map<UserAccountModel>(user.Account);

            return mappedUser;
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zip.Data.Entities;
using Zip.Domain.Models.User;
using Zip.Domain.User.Commands;

namespace Zip.Data.Units.Commands
{
    public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand, UserDetailsModel>
    {
        private readonly ZipDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserAccountCommandHandler(ZipDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDetailsModel> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .Include(x => x.Account)
                .SingleOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

            if (user == null)
                throw new ArgumentException("Uer does not exist."); ;

            if (user.Account != null)
                throw new ArgumentException("An account has already been created for this user.");

            var account = new Account
            {
                Id = Guid.NewGuid(),
                CreditBalance = 0m,
                CreditLimit = request.Request.CreditLimit,
                UserId = request.UserId
            };

            await _dbContext.AddAsync(account, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var mappedUser = _mapper.Map<UserDetailsModel>(user);
            mappedUser.Account = _mapper.Map<UserAccountModel>(user.Account);

            return mappedUser;
        }
    }
}

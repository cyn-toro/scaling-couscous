using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Zip.Data.Entities;
using Zip.Domain.Models.User;
using Zip.Domain.User.Commands;

namespace Zip.Data.Units.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserSummaryModel>
    {
        private readonly ZipDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(ZipDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserSummaryModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var emailTaken = _dbContext.Users.Any(x => x.Email.Equals(request.Request.Email));
            if (emailTaken)
                throw new ArgumentException($"{request.Request.Email} has already been registered.");

            var entity = new User
            {
                Id =request.Id,
                Email = request.Request.Email,
                MonthlySalary = request.Request.MonthlySalary,
                MonthlyExpenses = request.Request.MonthlyExpenses
            };

            await _dbContext.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserSummaryModel>(entity);
        }
    }
}

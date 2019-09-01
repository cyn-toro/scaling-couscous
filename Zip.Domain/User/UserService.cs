using System;
using System.Threading.Tasks;
using MediatR;
using Zip.Domain.Contracts;
using Zip.Domain.Models;
using Zip.Domain.Models.Account;
using Zip.Domain.Models.User;
using Zip.Domain.User.Commands;
using Zip.Domain.User.Queries;

namespace Zip.Domain.User
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;

        private const decimal MaxCreditLimit = 1000m;

        public UserService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<UserSummaryModel> Create(CreateUserRequest request)
        {
            if (request.MonthlyExpenses >= request.MonthlySalary)
                throw new ArgumentException("Expenses cannot be greater than salary");

            if (request.MonthlySalary - request.MonthlyExpenses < MaxCreditLimit)
                throw new ArgumentException($"The difference between monthly salary and expenses cannot be less than {MaxCreditLimit}");

            var newUser = await _mediator.Send(new CreateUserCommand(Guid.NewGuid(), request));
            return newUser;
        }

        public async Task<UserDetailsModel> Get(Guid id)
        {
            return await _mediator.Send(new GetUserQuery(id));
        }

        public async Task<Paged<UserSummaryModel>> GetAll(int pageSize, int pageNumber)
        {
            return await _mediator.Send(new PagedQuery<UserSummaryModel>(pageSize, pageNumber));
        }

        public async Task<UserDetailsModel> CreateAccount(Guid userId, CreateAccountRequest request)
        {
            if (request.CreditLimit > MaxCreditLimit)
                throw new ArgumentException($"Credit limit proposed exceeds the maximum limit of {MaxCreditLimit}");

            return await _mediator.Send(new CreateUserAccountCommand(userId, request));
        }

        public Task<AccountModel> GetUserAccount(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}

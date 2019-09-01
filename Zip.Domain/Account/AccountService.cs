using System.Threading.Tasks;
using MediatR;
using Zip.Domain.Contracts;
using Zip.Domain.Models;
using Zip.Domain.Models.Account;

namespace Zip.Domain.Account
{
    public class AccountService : IAccountService
    {
        private readonly IMediator _mediator;

        public AccountService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Paged<AccountModel>> Get(int pageSize, int pageNumber)
        {
            return await _mediator.Send(new PagedQuery<AccountModel>(pageSize, pageNumber));
        }
    }
}

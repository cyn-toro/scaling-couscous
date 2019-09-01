using MediatR;
using Zip.Domain.Models;
using Zip.Domain.Models.Account;

namespace Zip.Domain.Account.Queries
{
    public class GetAllAccountsQuery : IRequest<Paged<AccountModel>>
    {
        public GetAllAccountsQuery(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public int PageSize { get; }
        public int PageNumber { get; }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zip.Domain;
using Zip.Domain.Models;
using Zip.Domain.Models.Account;
using Zip.Domain.Models.User;

namespace Zip.Data.Units.Queries
{
    public class GetAllAccountsQueryHandler : IRequestHandler<PagedQuery<AccountModel>, Paged<AccountModel>>
    {
        private readonly ZipDbContext _zipDbContext;
        private readonly IMapper _mapper;

        public GetAllAccountsQueryHandler(ZipDbContext zipDbContext, IMapper mapper)
        {
            _zipDbContext = zipDbContext;
            _mapper = mapper;
        }

        public async Task<Paged<AccountModel>> Handle(PagedQuery<AccountModel> request, CancellationToken cancellationToken)
        {
            var accounts = _zipDbContext.Accounts;
            var currentPage = await accounts.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken);

            var totalItems = await accounts.CountAsync(cancellationToken);

            if (!currentPage.Any())
                return new Paged<AccountModel>(Enumerable.Empty<AccountModel>(), request.PageNumber, request.PageSize, totalItems);

            var mappedItems = _mapper.Map<IEnumerable<AccountModel>>(currentPage);
            return new Paged<AccountModel>(mappedItems, request.PageNumber, request.PageSize, totalItems);
        }
    }
}

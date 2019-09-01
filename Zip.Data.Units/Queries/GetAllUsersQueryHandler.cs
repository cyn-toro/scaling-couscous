using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zip.Domain;
using Zip.Domain.Models;
using Zip.Domain.Models.User;

namespace Zip.Data.Units.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<PagedQuery<UserSummaryModel>, Paged<UserSummaryModel>>
    {
        private readonly ZipDbContext _zipDbContext;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(ZipDbContext zipDbContext, IMapper mapper)
        {
            _zipDbContext = zipDbContext;
            _mapper = mapper;
        }

        public async Task<Paged<UserSummaryModel>> Handle(PagedQuery<UserSummaryModel> request, CancellationToken cancellationToken)
        {
            var users = _zipDbContext.Users;
            var currentPage = await users.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken);

            var totalItems = await users.CountAsync(cancellationToken);

            if (!currentPage.Any())
                return new Paged<UserSummaryModel>(Enumerable.Empty<UserSummaryModel>(), request.PageNumber, request.PageSize, totalItems);

            var mappedItems = _mapper.Map<IEnumerable<UserSummaryModel>>(currentPage);
            return new Paged<UserSummaryModel>(mappedItems, request.PageNumber, request.PageSize, totalItems);
        }
    }
}

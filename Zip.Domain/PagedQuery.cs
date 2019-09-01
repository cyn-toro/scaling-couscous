using System;
using MediatR;
using Zip.Domain.Models;

namespace Zip.Domain
{
    public class PagedQuery<TResponse> : IRequest<Paged<TResponse>>
    {
        private const int MaxPageSize = 100;

        public PagedQuery(int pageSize, int pageNumber)
        {
            if (pageSize <= 0)
                throw new ArgumentException($"{nameof(pageSize)} must be greater than 0.");

            if (pageNumber <= 0)
                throw new ArgumentException($"{nameof(pageNumber)} must be greater than 0.");

            if (pageSize > MaxPageSize)
                throw new ArgumentException($"Page size cannot exceed {pageSize}");

            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public int PageSize { get; }
        public int PageNumber { get; }
    }
}

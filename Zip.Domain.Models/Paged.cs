using System;
using System.Collections.Generic;

namespace Zip.Domain.Models
{
    public class Paged<T>
    {
        public IEnumerable<T> Items { get; }
        public int CurrentPage { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int TotalItems { get; }

        public Paged(IEnumerable<T> data, int currentPage, int pageSize, int totalCount)
        {
            Items = data;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalItems = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (float)pageSize);
        }
    }
}

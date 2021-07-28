using System;
using System.Collections.Generic;

namespace RealEstate.Domain.Common
{
    public class PagedResult<T>
    {
        public List<T> Items { get; private set; }

        public int TotalPages { get; private set; }

        public int ItemsFrom { get; private set; }

        public int ItemsTo { get; private set; }

        public int TotalItemsCount { get; private set; }

        public PagedResult(List<T> items, int totalCount, int pageSize, int pageNumber)
        {
            Items = items;
            TotalItemsCount = totalCount;
            ItemsFrom = pageSize * (pageNumber - 1) + 1;
            ItemsTo = ItemsFrom + pageSize - 1;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
    }
}

using System;
namespace RealEstate.Domain.Common
{
    public class RequestPaginationQuery
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}

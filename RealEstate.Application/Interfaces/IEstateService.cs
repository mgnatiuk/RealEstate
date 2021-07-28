using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Application.Dtos.ListDtos;
using RealEstate.Domain.Common;

namespace RealEstate.Application.Interfaces
{
    public interface IEstateService
    {
        Task<PagedResult<EstateListDto>> GetAllEstatesWithIncludes(RequestPaginationQuery query, List<string> includes);
    }
}

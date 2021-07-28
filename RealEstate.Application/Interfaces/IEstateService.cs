using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Application.Dtos.ListDtos;
using RealEstate.Domain.Common;

namespace RealEstate.Application.Interfaces
{
    public interface IEstateService
    {
        Task<PagedResult<BuildingListDto>> GetAllBuildingsWithIncludes(RequestQuery query, List<string> includes);
        Task<PagedResult<EstateListDto>> GetAllEstatesWithIncludes(RequestQuery query, List<string> includes);
    }
}

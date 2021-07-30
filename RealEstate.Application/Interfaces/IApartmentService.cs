using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Application.Dtos.Create;
using RealEstate.Application.Dtos.List;
using RealEstate.Domain.Common;

namespace RealEstate.Application.Interfaces
{
    public interface IApartmentService
    {
        Task<PagedResult<ApartmentListDto>> GetAllapartmentsWithIncludes(RequestPaginationQuery query, List<string> includes);
        Task<ApartmentListDto> GetByGuidWithIncludes(string guid, List<string> includes);
        Task<Guid> CreateApartment(ApartmentCreateDto dto);
    }
}

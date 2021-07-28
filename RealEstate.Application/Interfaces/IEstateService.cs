using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Application.Dtos.ListDtos;

namespace RealEstate.Application.Interfaces
{
    public interface IEstateService
    {
        Task<IEnumerable<EstateListDto>> GetAllWithIncludes(List<string> includes);
    }
}

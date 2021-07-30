using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RealEstate.Application.Dtos.List;
using RealEstate.Application.Interfaces;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Services
{
    public class EstateService : IEstateService
    {
        private readonly IEstateRepository _estateRepository;
        private readonly IMapper _mapper;

        public EstateService(IEstateRepository estateRepository, IMapper mapper)
        {
            _estateRepository = estateRepository;
            _mapper = mapper;
        }
 
        public async Task<PagedResult<EstateListDto>> GetAllEstatesWithIncludes(RequestPaginationQuery query, List<string> includes)
        {
            IEnumerable<Estate> data = await _estateRepository.GetAllWithIncludes(query, includes);

            var totalItemsCount = await _estateRepository.CountAll();

            var dtos = _mapper.Map<List<EstateListDto>>(data.AsQueryable());

            var result = new PagedResult<EstateListDto>(dtos, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
        }

        public async Task<EstateListDto> GetByGuidWithIncludes(string guid, List<string> includes)
        {
            Guid guidObj = new Guid(guid);

            Estate data = await _estateRepository.GetByIdWithIncludes(guidObj, includes);

            var dto = _mapper.Map<EstateListDto>(data);

            return dto;
        }
    }
}

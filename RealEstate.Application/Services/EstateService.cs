using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RealEstate.Application.Dtos.ListDtos;
using RealEstate.Application.Interfaces;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Services
{
    public class EstateService : IEstateService
    {
        private readonly IEstateRepository _estateRepository;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;

        public EstateService(IEstateRepository estateRepository, IBuildingRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
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
    }
}

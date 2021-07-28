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

        public async Task<PagedResult<BuildingListDto>> GetAllBuildingsWithIncludes(RequestQuery query, List<string> includes)
        {
            IEnumerable<Building> data = await _buildingRepository.GetAllWithIncludes(includes);

            var dtos = _mapper.Map<List<BuildingListDto>>(data.AsQueryable())
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = data.Count();

            var result = new PagedResult<BuildingListDto>(dtos.ToList(), totalItemsCount, query.PageSize, query.PageNumber);
            return result;
        }

        public async Task<PagedResult<EstateListDto>> GetAllEstatesWithIncludes(RequestQuery query, List<string> includes)
        {
            IEnumerable<Estate> data = await _estateRepository.GetAllWithIncludes(includes);

            var dtos = _mapper.Map<List<EstateListDto>>(data.AsQueryable())
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = data.Count();

            var result = new PagedResult<EstateListDto>(dtos.ToList(), totalItemsCount, query.PageSize, query.PageNumber);
            return result;
        }
    }
}

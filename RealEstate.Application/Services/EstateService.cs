using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RealEstate.Application.Dtos.ListDtos;
using RealEstate.Application.Interfaces;
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

        public async Task<IEnumerable<BuildingListDto>> GetAllBuildingsWithIncludes(List<string> includes)
        {
            IEnumerable<Building> data = await _buildingRepository.GetAllWithIncludes(includes);
            return _mapper.ProjectTo<BuildingListDto>(data.AsQueryable());
        }
    }
}

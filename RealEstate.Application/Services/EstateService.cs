using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using RealEstate.Application.Dtos.ListDtos;
using RealEstate.Application.Interfaces;
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

        public async Task<IEnumerable<EstateListDto>> GetAllWithIncludes(List<string> includes)
        {
            IEnumerable<Estate> data = await _estateRepository.GetAllWithIncludes(includes);
            return _mapper.ProjectTo<EstateListDto>(data.AsQueryable<Estate>());
        }
    }
}

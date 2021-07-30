using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RealEstate.Application.Dtos.Create;
using RealEstate.Application.Dtos.List;
using RealEstate.Application.Exceptions;
using RealEstate.Application.Interfaces;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Services
{
    public class ApartmentService : IApartmentService
    {

        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public ApartmentService(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateApartment(ApartmentCreateDto dto)
        {
            Apartment apartment = _mapper.Map<Apartment>(dto);

            await _apartmentRepository.Add(apartment);

            return apartment.Id;
        }

        public async Task<PagedResult<ApartmentListDto>> GetAllapartmentsWithIncludes(RequestPaginationQuery query, List<string> includes)
        {
            IEnumerable<Apartment> data = await _apartmentRepository.GetAllWithIncludes(query, includes);

            var totalItemsCount = await _apartmentRepository.CountAll();

            var dtos = _mapper.Map<List<ApartmentListDto>>(data.AsQueryable());

            var result = new PagedResult<ApartmentListDto>(dtos, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
        }

        public async Task<ApartmentListDto> GetByGuidWithIncludes(string guid, List<string> includes)
        {
            Guid guidObj = new Guid(guid);

            Apartment apartment = await _apartmentRepository.GetByIdWithIncludes(guidObj, includes);

            if (apartment is null)
                throw new NotFoundException(string.Format("apartment does not exist with id: {0}."));
 
            var dto = _mapper.Map<ApartmentListDto>(apartment);
 
            return dto;
        }
    
    }
}

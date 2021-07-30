﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RealEstate.Application.Dtos.Create;
using RealEstate.Application.Dtos.List;
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
            Address address = new Address(dto.Address.Street, dto.Address.City, dto.Address.CountryCode, dto.Address.PostalCode, dto.Address.AddressNumber, dto.Address.FlatNumber, dto.Address.Region);

            Apartment apartment = new Apartment(dto.Rooms, dto.BuildingLevel,dto.AvailableFrom, dto.YearOfBuilding, dto.CautionPrice, dto.BuildingMaterial, dto.HeatingType, dto.FinishingType, dto.Title, address, dto.OfferType, dto.AgreementType, dto.HasProvision, dto.Description, dto.Area, dto.AdditionalArea, dto.Price, dto.ApartmentLevel);

            await _apartmentRepository.Add(apartment);

            return address.Id;
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

            Apartment data = await _apartmentRepository.GetByIdWithIncludes(guidObj, includes);
 
            var dto = _mapper.Map<ApartmentListDto>(data);
 
            return dto;
        }
    
    }
}

using System;
using AutoMapper;
using RealEstate.Application.Dtos.Create;
using RealEstate.Application.Dtos.List;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Profiles
{
    public class ApartmentProfile : Profile
    {
        public ApartmentProfile()
        {
            CreateMap<Apartment, ApartmentListDto>();

            CreateMap<ApartmentCreateDto, Apartment>()
                .ForMember(r => r.Address,
                    c => c.MapFrom(dto => new Address(dto.Address.Street, dto.Address.City, dto.Address.CountryCode, dto.Address.PostalCode, dto.Address.AddressNumber, dto.Address.FlatNumber, dto.Address.Region)));

            CreateMap<ApartmentCreateDto, Building>();

            CreateMap<ApartmentCreateDto, Estate>();
        }
    }
}

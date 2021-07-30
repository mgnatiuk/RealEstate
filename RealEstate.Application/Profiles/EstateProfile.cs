using System;
using AutoMapper;
using RealEstate.Application.Dtos;
using RealEstate.Application.Dtos.Create;
using RealEstate.Application.Dtos.List;
using RealEstate.Application.Extensions;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Profiles
{
    public class EstateProfile : Profile
    {
        public EstateProfile()
        {
            CreateMap<Address, AddressListDto>();

            CreateMap<BaseEntity, EstateListDto>()
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(src => src.CreatedDate.GetDateWithTime())
                )
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(src => src.UpdatedDate.HasValue ? src.UpdatedDate.Value.GetDateWithTime() : null)
                );

            CreateMap<Estate, EstateListDto>()
                .Include<Building, BuildingListDto>()
                .Include<Apartment, ApartmentListDto>()
                .Include<PrivateHouse, PrivateHouseListDto>();

            CreateMap<Building, BuildingListDto>()
                .Include<Apartment, ApartmentListDto>()
                .Include<PrivateHouse, PrivateHouseListDto>()
                .ForMember(
                    dest => dest.AvailableFrom,
                    opt => opt.MapFrom(src => src.AvailableFrom.GetDateOnly()
                ));

            CreateMap<Estate, BuildingListDto>();

            CreateMap<Apartment, ApartmentListDto>();

            CreateMap<PrivateHouse, PrivateHouseListDto>();

            

            CreateMap<ApartmentCreateDto, Apartment>()
                .ForMember(r => r.Address,
                    c => c.MapFrom(dto => new Address(dto.Address.Street, dto.Address.City, dto.Address.CountryCode, dto.Address.PostalCode, dto.Address.AddressNumber, dto.Address.FlatNumber, dto.Address.Region)));

            CreateMap<ApartmentCreateDto, Building>();

            CreateMap<ApartmentCreateDto, Estate>();

            CreateMap<CreateAddressDto, Address>();
        }
    }
}

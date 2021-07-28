using System;
using AutoMapper;
using RealEstate.Application.Dtos;
using RealEstate.Application.Dtos.ListDtos;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Profiles
{
    public class EstateProfile : Profile
    {
        public EstateProfile()
        {
            CreateMap<Address, AddressDto>();

            CreateMap<Estate, EstateListDto>()
                .IncludeAllDerived();

            CreateMap<Building, BuildingListDto>()
                .IncludeAllDerived()
                .ForMember(dest => dest.AvailableFrom, opt => opt.MapFrom(src => src.AvailableFrom));

            CreateMap<Estate, BuildingListDto>()
                .IncludeAllDerived(); ;
        }
    }
}

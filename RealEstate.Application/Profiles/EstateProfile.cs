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

            CreateMap<Estate, EstateListDto>();

            CreateMap<Estate, BuildingListDto>()
                .IncludeBase<Estate, EstateListDto>();

            CreateMap<Estate, ApartmentListDto>()
                .IncludeBase<Estate, BuildingListDto>();

            CreateMap<Estate, PrivatHouseListDto>()
                .IncludeBase<Estate, BuildingListDto>();
        }
    }
}

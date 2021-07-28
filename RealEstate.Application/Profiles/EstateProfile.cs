using System;
using AutoMapper;
using RealEstate.Application.Dtos;
using RealEstate.Application.Dtos.ListDtos;
using RealEstate.Application.Extensions;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Profiles
{
    public class EstateProfile : Profile
    {
        public EstateProfile()
        {
            

            CreateMap<Address, AddressDto>();

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
                .IncludeAllDerived();

            CreateMap<Building, BuildingListDto>()
                .IncludeAllDerived()
                .ForMember(dest => dest.AvailableFrom, opt => opt.MapFrom(src => src.AvailableFrom.GetDateOnly()));

            CreateMap<Estate, BuildingListDto>()
                .IncludeAllDerived();
        }
    }
}

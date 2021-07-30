using System;
using AutoMapper;
using RealEstate.Application.Dtos.List;
using RealEstate.Application.Extensions;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Profiles
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<Building, BuildingListDto>()
                .Include<Apartment, ApartmentListDto>()
                .Include<PrivateHouse, PrivateHouseListDto>()
                .ForMember(
                    dest => dest.AvailableFrom,
                    opt => opt.MapFrom(src => src.AvailableFrom.GetDateOnly()
                ));
        }
    }
}

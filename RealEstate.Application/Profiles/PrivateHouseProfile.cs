using System;
using AutoMapper;
using RealEstate.Application.Dtos.List;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Profiles
{
    public class PrivateHouseProfile : Profile
    {
        public PrivateHouseProfile()
        {
            CreateMap<PrivateHouse, PrivateHouseListDto>();
        }
    }
}

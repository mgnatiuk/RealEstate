using System;
using AutoMapper;
using RealEstate.Application.Dtos.Create;
using RealEstate.Application.Dtos.List;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressListDto>();

            CreateMap<CreateAddressDto, Address>();
        }
    }
}

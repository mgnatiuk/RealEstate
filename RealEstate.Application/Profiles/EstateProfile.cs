using AutoMapper;
using RealEstate.Application.Dtos.List;
using RealEstate.Application.Extensions;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Profiles
{
    public class EstateProfile : Profile
    {
        public EstateProfile()
        {
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

            CreateMap<Estate, BuildingListDto>();
        }
    }
}

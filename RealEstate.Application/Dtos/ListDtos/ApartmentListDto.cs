using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Application.Dtos.ListDtos
{
    public class ApartmentListDto : BuildingListDto
    {
        [Display(Name = "apartment level")]
        public int ApartmentLevel { get; set; }
    }
}

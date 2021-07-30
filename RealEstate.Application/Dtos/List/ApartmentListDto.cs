using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Application.Dtos.List
{
    public class ApartmentListDto : BuildingListDto
    {
        [Display(Name = "apartment level")]
        public int ApartmentLevel { get; set; }
    }
}

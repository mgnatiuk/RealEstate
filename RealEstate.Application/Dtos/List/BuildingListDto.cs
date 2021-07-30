using System;
using System.ComponentModel.DataAnnotations;
using RealEstate.Domain.Enums;

namespace RealEstate.Application.Dtos.List
{
    public class BuildingListDto : EstateListDto
    {
        [Display(Name = "rooms")]
        public int Rooms { get; set; }

        [Display(Name = "building level")]
        public int BuildingLevel { get; set; }

        [Display(Name = "avaliable from")]
        public string AvailableFrom { get; set; }

        [Display(Name = "year of building")]
        public int YearOfBuilding { get; set; }

        [Display(Name = "caution price")]
        public double? CautionPrice { get; set; }

        [Display(Name = "building type")]
        public BuildingType BuildingType { get; set; }

        [Display(Name = "building material")]
        public BuildingMaterial BuildingMaterial { get; set; }

        [Display(Name = "heating type")]
        public HeatingType HeatingType { get; set; }

        [Display(Name = "finishing type")]
        public FinishingType FinishingType { get; set; }
    }
}

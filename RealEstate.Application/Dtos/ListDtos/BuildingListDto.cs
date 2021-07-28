using System;
using System.ComponentModel.DataAnnotations;
using RealEstate.Domain.Enums;

namespace RealEstate.Application.Dtos.ListDtos
{
    public class BuildingListDto : EstateListDto
    {
        [Display(Name = "rooms")]
        public int Rooms { get; private set; }

        [Display(Name = "building level")]
        public int BuildingLevel { get; private set; }

        [Display(Name = "avaliable from")]
        public DateTime AvailableFrom { get; private set; }

        [Display(Name = "year of building")]
        public int YearOfBuilding { get; private set; }

        [Display(Name = "caution price")]
        public double? CautionPrice { get; private set; }

        [Display(Name = "building type")]
        public BuildingType BuildingType { get; private set; }

        [Display(Name = "building material")]
        public BuildingMaterial BuildingMaterial { get; private set; }

        [Display(Name = "heating type")]
        public HeatingType HeatingType { get; private set; }

        [Display(Name = "finishing type")]
        public FinishingType FinishingType { get; private set; }
    }
}

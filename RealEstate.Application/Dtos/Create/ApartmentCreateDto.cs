using System;
using RealEstate.Domain.Enums;

namespace RealEstate.Application.Dtos.Create
{
    public class ApartmentCreateDto
    {
        public int Rooms { get; set; }

        public int BuildingLevel { get; set; }

        public DateTime AvailableFrom { get; set; }

        public int YearOfBuilding { get; set; }

        public double? CautionPrice { get; set; }

        public BuildingType BuildingType { get; set; }

        public BuildingMaterial BuildingMaterial { get; set; }

        public HeatingType HeatingType { get; set; }

        public FinishingType FinishingType { get; set; }

        public AgreementType AgreementType { get; set; }

        public OfferType OfferType { get; set; }

        public string Title { get; set; }

        public bool HasProvision { get; set; }

        public string Description { get; set; }

        public double Area { get; set; }

        public double? AdditionalArea { get; set; }

        public double Price { get; set; }
 
        public int ApartmentLevel { get; set; }

        public CreateAddressDto Address { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Entities
{
    public abstract class Building : Estate
    {

        public Building(int rooms, int buildingLevel, DateTime availableFrom, int yearOfBuilding, double? cautionPrice, BuildingType buildingType, BuildingMaterial buildingMaterial, HeatingType heatingType, FinishingType finishingType, string title, Address address, OfferType offerType, AgreementType agreementType, bool hasProvision, string description, double area, double? additionalArea, double price)
      : base(title, address, offerType, agreementType, hasProvision, description, area, additionalArea, price)
        {
            Rooms = rooms;
            BuildingLevel = buildingLevel;
            AvailableFrom = availableFrom;
            YearOfBuilding = yearOfBuilding;
            CautionPrice = cautionPrice;
            BuildingType = buildingType;
            BuildingMaterial = buildingMaterial;
            HeatingType = heatingType;
            FinishingType = finishingType;
        }

        protected Building(): base()
        {
        }

        #region Class properties
        public int Rooms { get; private set; }

        public int BuildingLevel { get; private set; }

        public DateTime AvailableFrom { get; private set; }

        public int YearOfBuilding { get; private set; }

        public double? CautionPrice { get; private set; }

        public BuildingType BuildingType { get; private set; }

        public BuildingMaterial BuildingMaterial { get; private set; }

        public HeatingType HeatingType { get; private set; }

        public FinishingType FinishingType { get; private set; }
        #endregion

        #region Public methods
        public void UpdateBuilding(int rooms, int buildingLevel, DateTime availableFrom, int yearOfBuilding, double? cautionPrice, BuildingType buildingType, BuildingMaterial buildingMaterial, HeatingType heatingType, FinishingType finishingType, string title, Address address, OfferType offerType, AgreementType agreementType, bool hasProvision, string description, double area, double? additionalArea, double price)
        {
            Rooms = rooms;
            BuildingLevel = buildingLevel;
            AvailableFrom = availableFrom;
            YearOfBuilding = yearOfBuilding;
            CautionPrice = cautionPrice;
            BuildingType = buildingType;
            BuildingMaterial = buildingMaterial;
            HeatingType = heatingType;
            FinishingType = finishingType;

            base.UpdateEstate(title, offerType, agreementType, hasProvision, description, area, additionalArea, price, address);
        }
        #endregion
    }
}

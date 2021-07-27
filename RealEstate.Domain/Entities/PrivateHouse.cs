using System;
using System.ComponentModel.DataAnnotations;
using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Entities
{
    public class PrivateHouse : Building
    {
        protected PrivateHouse()
        {
        }

        public PrivateHouse(int rooms, int buildingLevel, DateTime availableFrom, int yearOfBuilding, double? cautionPrice, BuildingMaterial buildingMaterial, HeatingType heatingType, FinishingType finishingType, string title, Address address, OfferType offerType, AgreementType agreementType, bool hasProvision, string description, double area, double? additionalArea, double price) : base(rooms, buildingLevel, availableFrom, yearOfBuilding, cautionPrice, BuildingType.PrivateHouse, buildingMaterial, heatingType, finishingType, title, address, offerType, agreementType, hasProvision, description, area, additionalArea, price)
        {

        }

        #region Class properties
        #endregion

        #region Public methods
        public void UpdatePrivateHouse(int rooms, int buildingLevel, DateTime availableFrom, int yearOfBuilding, double? cautionPrice, BuildingType buildingType, BuildingMaterial buildingMaterial, HeatingType heatingType, FinishingType finishingType, string title, Address address, OfferType offerType, AgreementType agreementType, bool hasProvision, string description, double area, double? additionalArea, double price)
        {
            base.UpdateBuilding(rooms, buildingLevel, availableFrom, yearOfBuilding, cautionPrice, buildingType, buildingMaterial, heatingType, finishingType, title, address, offerType, agreementType, hasProvision, description, area, additionalArea, price);
        }
        #endregion
    }
}

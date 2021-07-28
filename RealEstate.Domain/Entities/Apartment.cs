using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Entities
{
    public class Apartment : Building
    {
        protected Apartment() 
        {
        }

        public Apartment(int rooms, int buildingLevel, DateTime availableFrom, int yearOfBuilding, double? cautionPrice, BuildingMaterial buildingMaterial, HeatingType heatingType, FinishingType finishingType, string title, Address address, OfferType offerType, AgreementType agreementType, bool hasProvision, string description, double area, double? additionalArea, double price, int apartmentLevel) : base(rooms, buildingLevel, availableFrom, yearOfBuilding, cautionPrice, BuildingType.ApartamentBuilding, buildingMaterial, heatingType, finishingType, title, address, offerType, agreementType, hasProvision, description, area, additionalArea, price)
        {
            ApartmentLevel = apartmentLevel;
        }
 
        #region Class properties
        public int ApartmentLevel { get; private set; }
        #endregion

        #region Public methods
        public void UpdateApartment(int apartmentLevel,int rooms, int buildingLevel, DateTime availableFrom, int yearOfBuilding, double? cautionPrice, BuildingType buildingType, BuildingMaterial buildingMaterial, HeatingType heatingType, FinishingType finishingType, string title, Address address, OfferType offerType, AgreementType agreementType, bool hasProvision, string description, double area, double? additionalArea, double price)
        {
            ApartmentLevel = apartmentLevel;

            base.UpdateBuilding(rooms, buildingLevel, availableFrom, yearOfBuilding,cautionPrice, buildingType, buildingMaterial, heatingType, finishingType, title, address, offerType, agreementType, hasProvision, description, area, additionalArea, price);
        }
        #endregion
    }
}
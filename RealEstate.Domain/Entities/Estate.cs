using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Entities
{
    public abstract class Estate : BaseEntity
    {
       
        public Estate(string title, Address address, OfferType offerType, AgreementType agreementType, bool hasProvision, string description, double area, double? additionalArea, double price) : base()
        {
            Title = title;
            Address = address;
            OfferType = offerType;
            AgreementType = agreementType;
            HasProvision = hasProvision;
            Description = description;
            Area = area;
            AdditionalArea = additionalArea;
            Price = price;
        }

        protected Estate() : base()
        {
        }

        #region Class properties
        public string Title { get; private set; }

        public OfferType OfferType { get; private set; }

        public bool HasProvision { get; private set; }

        public string Description { get; private set; }

        public double Area { get; private set; }

        public double? AdditionalArea { get; private set; }

        public double Price { get; private set; }

        public AgreementType AgreementType { get; private set; }

        public Address Address { get; private set; }
        #endregion

        #region Methods
        public void UpdateEstate(string title, OfferType offerType, AgreementType agreementType, bool hasProvision, string description, double area, double? additionalArea, double price, Address address)
        {
            Title = title;
            OfferType = offerType;
            AgreementType = agreementType;
            HasProvision = hasProvision;
            Description = description;
            Area = area;
            AdditionalArea = additionalArea;
            Price = price;

            base.UpdateModificationDate();

            Address.UpdateAddress(address.Street, address.City, address.CountryCode, address.PostalCode, address.AddressNumber, address.FlatNumber, address.Region);
        }
        #endregion
    }
}

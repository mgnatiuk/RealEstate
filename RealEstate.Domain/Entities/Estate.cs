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
        [Display(Name="title")]
        public string Title { get; private set; }

        [Display(Name="offer type")]
        public OfferType OfferType { get; private set; }

        [Display(Name="has provision")]
        public bool HasProvision { get; private set; }

        [Display(Name="description")]
        public string Description { get; private set; }

        [Display(Name="area")]
        public double Area { get; private set; }

        [Display(Name = "additional area")]
        public double? AdditionalArea { get; private set; }

        [Display(Name="price")]
        public double Price { get; private set; }

        [Display(Name="agreement type")]
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

            Address.UpdateAddress(address.Street, address.City, address.CountryCode, address.PostalCode, address.AddressNumber, address.FlatNumber, address.Region);
        }
        #endregion
    }
}

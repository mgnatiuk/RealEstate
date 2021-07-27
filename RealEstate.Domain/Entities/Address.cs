using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    public class Address : BaseEntity
    {
        public Address(string street, string city, string countryCode, string postalCode, string addressNumber, string flatNumber, string region) : base()
        {
            Street = street;
            City = city;
            CountryCode = countryCode;
            PostalCode = postalCode;
            AddressNumber = addressNumber;
            FlatNumber = flatNumber;
            Region = region;
        }

        #region Class properties
        [Display(Name = "street")]
        public string Street { get; private set; }

        [Display(Name = "city")]
        public string City { get; private set; }

        [Display(Name = "country")]
        public string CountryCode { get; private set; }

        [Display(Name="postal code")]
        public string PostalCode { get; private set; }

        [Display(Name="address number")]
        public string AddressNumber { get; private set; }

        [Display(Name = "flat number")]
        public string FlatNumber { get; private set; }

        [Display(Name="region")]
        public string Region { get; private set; }
 
        public Estate Estate { get; private set; }

        public Guid EstateId { get; private set; }
        #endregion

        #region Public methods
        public void UpdateAddress(string street, string city, string countryCode, string postalCode, string addressNumber, string flatNumber, string region)
        {
            Street = street;
            City = city;
            CountryCode = countryCode;
            PostalCode = postalCode;
            AddressNumber = addressNumber;
            Region = region;
            FlatNumber = flatNumber;
        }
        #endregion
    }
}

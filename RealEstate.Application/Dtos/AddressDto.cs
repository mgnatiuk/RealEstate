using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Application.Dtos
{
    public class AddressDto
    {
        [Display(Name="street")]
        public string Street { get; set; }

        [Display(Name = "city")]
        public string City { get; set; }

        [Display(Name = "country code")]
        public string CountryCode { get; set; }

        [Display(Name = "postal code")]
        public string PostalCode { get; set; }

        [Display(Name = "address number")]
        public string AddressNumber { get; set; }

        [Display(Name = "flatNumber")]
        public string FlatNumber { get; set; }

        [Display(Name = "region")]
        public string Region { get; set; }

        public Guid EstateId { get; set; }
    }
}

using System;
namespace RealEstate.Application.Dtos.Create
{
    public class CreateAddressDto
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string CountryCode { get; set; }

        public string PostalCode { get; set; }

        public string AddressNumber { get; set; }

        public string FlatNumber { get; set; }

        public string Region { get; set; }
    }
}
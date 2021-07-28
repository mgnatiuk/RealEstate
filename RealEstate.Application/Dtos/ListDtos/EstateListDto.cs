using System;
using System.ComponentModel.DataAnnotations;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;

namespace RealEstate.Application.Dtos.ListDtos
{
    public class EstateListDto
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Display(Name = "title")]
        public string Title { get; set; }

        [Display(Name = "offer type")]
        public OfferType OfferType { get; set; }

        [Display(Name = "has provision")]
        public bool HasProvision { get; set; }

        [Display(Name = "description")]
        public string Description { get; set; }

        [Display(Name = "area")]
        public double Area { get; set; }

        [Display(Name = "additional area")]
        public double? AdditionalArea { get; set; }

        [Display(Name = "price")]
        public double Price { get; set; }

        [Display(Name = "agreement type")]
        public AgreementType AgreementType { get; set; }

        public AddressDto Address { get; set; }
    }
}

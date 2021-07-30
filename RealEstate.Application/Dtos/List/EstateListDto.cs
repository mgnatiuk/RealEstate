using System;
using System.ComponentModel.DataAnnotations;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;

namespace RealEstate.Application.Dtos.List
{
    public class EstateListDto
    {
        public Guid Id { get; set; }

        [Display(Name = "created date")]
        public string CreatedDate { get; set; }

        [Display(Name = "updated date")]
        public string UpdatedDate { get; set; }

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

        public AddressListDto Address { get; set; }
    }
}

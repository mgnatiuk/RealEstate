using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Domain.Enums
{
    public enum AgreementType
    {
        [Display(Name="rent")]
        Rent,
        [Display(Name = "sale")]
        Sale
    }
}

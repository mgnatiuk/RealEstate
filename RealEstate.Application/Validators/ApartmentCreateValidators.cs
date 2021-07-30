using System;
using FluentValidation;
using RealEstate.Application.Dtos.Create;

namespace RealEstate.Application.Validators
{
    public class ApartmentCreateValidators : AbstractValidator<ApartmentCreateDto>
    {
        public ApartmentCreateValidators()
        {

        }
    }
}

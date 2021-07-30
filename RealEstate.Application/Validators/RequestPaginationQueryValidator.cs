using System;
using System.Linq;
using FluentValidation;
using RealEstate.Domain.Common;

namespace RealEstate.Application.Validators
{
    public class RequestPaginationQueryValidator : AbstractValidator<RequestPaginationQuery>
    {
        private int[] allowedPageSizes = new[] { 5, 10, 15 };

        public RequestPaginationQueryValidator()
        {
            RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);

            RuleFor(r => r.PageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure(nameof(RequestPaginationQuery.PageSize), $"{nameof(RequestPaginationQuery.PageSize)} must in [{string.Join(",", allowedPageSizes)}]");
                }
            });
        }
    }
}

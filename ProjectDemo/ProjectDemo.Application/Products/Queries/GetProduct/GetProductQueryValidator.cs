using FluentValidation;
using System;

namespace ProjectDemo.Application.Products.Queries.GetProduct
{
    public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductQueryValidator()
        {
            RuleFor(q => q.Id)
                .NotEmpty()
                .Must(g => Guid.TryParse(g, out _))
                .WithMessage("Id must be a valid guid.");
        }
    }
}

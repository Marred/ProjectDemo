using FluentValidation;
using System;

namespace ProjectDemo.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .Must(c => Guid.TryParse(c, out _))
                .WithMessage("Id must be a valid guid.");

            RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
            RuleFor(c => c.Price).GreaterThanOrEqualTo(0.00M);
        }
    }
}

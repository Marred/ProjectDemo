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

            RuleFor(c => c.Name)
                .MaximumLength(100)
                .When(c => !string.IsNullOrEmpty(c.Name));

            RuleFor(c => c.Price)
                .GreaterThan(0.00M)
                .When(c => c.Price != default);
        }
    }
}

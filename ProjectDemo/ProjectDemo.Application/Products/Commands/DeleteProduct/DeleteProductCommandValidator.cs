using FluentValidation;
using System;

namespace ProjectDemo.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .Must(g => Guid.TryParse(g, out _))
                .WithMessage("Id must be a valid guid.");
        }
    }
}

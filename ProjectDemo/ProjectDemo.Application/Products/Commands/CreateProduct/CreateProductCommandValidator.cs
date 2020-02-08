using FluentValidation;

namespace ProjectDemo.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.Name).MaximumLength(100).NotEmpty();
            RuleFor(c => c.Price).GreaterThan(0.00M);
        }
    }
}

using FluentValidation;

namespace ProjectDemo.Application.Products.Queries.GetProductsPage
{
    public class GetProductsPageQueryValidator : AbstractValidator<GetProductsPageQuery>
    {
        public GetProductsPageQueryValidator()
        {
            RuleFor(q => q.PageNumber).GreaterThan(0);
            RuleFor(q => q.PageSize).GreaterThan(0);
        }
    }
}

using MediatR;

namespace ProjectDemo.Application.Products.Queries.GetProductsPage
{
    public class GetProductsPageQuery : IRequest<ProductsPageDto>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}

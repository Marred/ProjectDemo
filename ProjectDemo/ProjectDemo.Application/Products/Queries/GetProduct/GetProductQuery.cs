using MediatR;

namespace ProjectDemo.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductDto>
    {
        public string Id { get; set; }
    }
}

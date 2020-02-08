using MediatR;

namespace ProjectDemo.Application.Products.Queries.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

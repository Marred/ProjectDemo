using MediatR;

namespace ProjectDemo.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

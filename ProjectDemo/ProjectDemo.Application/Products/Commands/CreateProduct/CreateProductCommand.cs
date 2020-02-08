using MediatR;

namespace ProjectDemo.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<string>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

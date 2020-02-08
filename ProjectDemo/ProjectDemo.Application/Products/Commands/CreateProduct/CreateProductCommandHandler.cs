using MediatR;
using ProjectDemo.Domain.Products;
using ProjectDemo.Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectDemo.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
    {
        private ProjectDemoDbContext _context;

        public CreateProductCommandHandler(ProjectDemoDbContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Price);

            _context.Add(product);
            await _context.SaveChangesAsync();

            return product.Id.ToString();
        }
    }
}

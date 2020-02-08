using MediatR;
using ProjectDemo.Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectDemo.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly ProjectDemoDbContext _context;

        public UpdateProductCommandHandler(ProjectDemoDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);

            if (!string.IsNullOrEmpty(request.Name))
            {
                product.SetName(request.Name);
            }
            if (request.Price != default)
            {
                product.SetPrice(request.Price);
            }

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

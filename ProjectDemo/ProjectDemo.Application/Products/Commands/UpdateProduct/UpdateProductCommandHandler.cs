using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDemo.Application.Exceptions;
using ProjectDemo.Domain.Products;
using ProjectDemo.Persistence;
using System;
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
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id.Equals(Guid.Parse(request.Id)));

            if (product == default)
                throw new EntityNotFoundException($"Could not find product with id {request.Id}.");

            product.SetName(request.Name);
            product.SetPrice(request.Price);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

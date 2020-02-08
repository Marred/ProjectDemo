using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDemo.Application.Exceptions;
using ProjectDemo.Domain.Products;
using ProjectDemo.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectDemo.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private ProjectDemoDbContext _context;

        public DeleteProductCommandHandler(ProjectDemoDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id.Equals(Guid.Parse(request.Id)));

            if (product == default)
                throw new EntityNotFoundException($"Could not find product with id {request.Id}.");

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

using MediatR;
using ProjectDemo.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
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
            var product = await _context.Products.FindAsync(request.Id);

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

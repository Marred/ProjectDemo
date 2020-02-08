using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDemo.Application.Exceptions;
using ProjectDemo.Domain.Products;
using ProjectDemo.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectDemo.Application.Products.Queries.GetProduct
{
    class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly ProjectDemoDbContext _context;
        public GetProductQueryHandler(ProjectDemoDbContext context)
        {
            _context = context;
        }
        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id.Equals(Guid.Parse(request.Id)));

            if (product == default)
                throw new EntityNotFoundException($"Could not find product with id {request.Id}.");

            return new ProductDto
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}

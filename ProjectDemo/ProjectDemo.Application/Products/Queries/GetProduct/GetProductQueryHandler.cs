using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDemo.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
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
            var product = await _context.Products.SingleAsync(p => p.Id.Equals(Guid.Parse(request.Id)));

            return new ProductDto
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}

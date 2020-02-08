using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDemo.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectDemo.Application.Products.Queries.GetProductsPage
{
    public class GetProductsPageQueryHandler : IRequestHandler<GetProductsPageQuery, ProductsPageDto>
    {
        private readonly ProjectDemoDbContext _conext;
        public GetProductsPageQueryHandler(ProjectDemoDbContext context)
        {
            _conext = context;
        }
        public async Task<ProductsPageDto> Handle(GetProductsPageQuery request, CancellationToken cancellationToken)
        {
            var elementsToSkip = request.PageSize * (request.PageNumber - 1);

            var products = await _conext.Products
                .Skip(elementsToSkip)
                .Take(request.PageSize)
                .Select(p => new ProductDto
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    Price = p.Price
                })
                .ToListAsync();

            var elementssCount = _conext.Products.Count();

            var page = new ProductsPageDto
            {
                Products = products,
                PageNumber = request.PageNumber,
                ElementsCount = elementssCount
            };

            return page;
        }
    }
}

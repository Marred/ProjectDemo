using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDemo.Application.Products.Queries.GetProductsPage
{
    public class ProductsPageDto
    {
        public int PageNumber { get; set; }
        public int ElementsCount { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}

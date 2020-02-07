using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectDemo.Application.Products.Queries.GetProductsPage;
using System.Threading.Tasks;

namespace ProjectDemo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<ProductsPageDto>> GetProductsPageAsync(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(await _mediator.Send(new GetProductsPageQuery { PageNumber = pageNumber, PageSize = pageSize }));
        }
    }
}
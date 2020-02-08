using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectDemo.Application.Products.Commands.CreateProduct;
using ProjectDemo.Application.Products.Commands.DeleteProduct;
using ProjectDemo.Application.Products.Commands.UpdateProduct;
using ProjectDemo.Application.Products.Queries.GetProduct;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductAsync(string id)
        {
            return Ok(await _mediator.Send(new GetProductQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateproductAsync(CreateProductCommand command)
        {
            var id = await _mediator.Send(command);

            return new CreatedAtRouteResult("", new { Id = id });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProductAstync(UpdateProductCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductAsync(string id)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }
    }
}
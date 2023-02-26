using Catalog.Command;
using Catalog.Database;
using Catalog.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Catalog.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       private readonly ISender _sender;       

        public ProductsController(ISender sender)
        {
            _sender = sender;       
        }

        [HttpGet]        
        [SwaggerOperation(Summary = "Returning the list of Products", OperationId = "GetAllProducts")]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _sender.Send(new GetAllProductsQuery());         
        }


        [HttpGet("{productId:int}")]
        [SwaggerOperation(Summary = "Returning Product based upon {productId}", OperationId = "GetProduct")]
        public async Task<Product?> GetProduct(int productId)
        {
            return await _sender.Send(new GetProductQuery(productId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Add New Products", OperationId = "AddProduct")]
        public async Task<ActionResult> AddProduct(Product product)
        {
            var result = await _sender.Send(new AddProductCommand(product));
            return StatusCode(result);
        }

        [HttpPut("{ProductId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Update Product by {ProductId}", OperationId = "UpdateProduct")]
        public async Task<ActionResult> UpdateProduct(int ProductId, Product product)
        {
            var result = await _sender.Send(new UpdatProductCommand(ProductId, product));
            return StatusCode(result);
        }

        [HttpDelete("{productId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Delete Product by {productId}", OperationId = "DeleteProduct")]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            var result = await _sender.Send(new DeleteProductCommand(productId));
            return StatusCode(result);

        }
    }


}

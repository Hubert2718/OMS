using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponce<List<Product>>>> GetProducts()
        {
            var response = await productService.GetProducts();
            if(!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponce<List<Product>>>> AddProduct(Product product)
        {
            var response = await productService.AddProduct(product);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponce<List<Product>>>> UpdateProduct(Product product)
        {
            var response = await productService.UpdateProduct(product);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult<ServiceResponce<List<Product>>>> DeleteProduct(int productId)
        {
            var response = await productService.DeleteProduct(productId);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }
    }
}

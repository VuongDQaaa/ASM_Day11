using ASM_Day11.DTO;
using ASM_Day11.Entities;
using ASM_Day11.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ASM_Day11.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost("/add-product")]
        public async Task AddProduct([FromBody]ProductDTO product)
        {
            await _service.AddProduct(product);
        }

        [HttpGet("/all-product")]
        public async Task<List<Product>> GetAllProduct()
        {
            return await _service.GetAllProducts();
        }

        [HttpGet("/product")]
        public async Task<Product> GetProductById(int id)
        {
            return await _service.GetProductById(id);
        }

        [HttpPut("/update-product")]
        public async Task UpdateProduct(int id, [FromBody]ProductDTO dto)
        {
            await _service.UpdateProduct(id, dto);
        }

        [HttpDelete("/delete-product")]
        public async Task DeleteProduct(int id)
        {
            await _service.DeleteProduct(id);
        }
    }
}
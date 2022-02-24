using ASM_Day11.DTO;
using ASM_Day11.Entities;
using ASM_Day11.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ASM_Day11.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost("/add-category")]
        public async Task AddCategory([FromBody]CategoryDTO category)
        {
            await _service.AddCategory(category);
        }

        [HttpGet("/get-all-categories")]
        public async Task<List<Category>> GetAllCategories()
        {
            return await _service.GetAllCategories();
        }

        [HttpGet("/category")]
        public async Task<Category> GetCategoryById(int id)
        {
            return await _service.GetCategoryById(id);
        }

        [HttpPut("/update-category")]
        public async Task UpdateCategory(int id, [FromBody]CategoryDTO category)
        {
            await _service.UpdateCategory(id, category);
        }

        [HttpDelete("/delete-category")]
        public async Task DeleteCategory(int id)
        {
            await _service.DeleteCategory(id);
        }
    }
}
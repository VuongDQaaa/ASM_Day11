using ASM_Day11.DB;
using ASM_Day11.DTO;
using ASM_Day11.Entities;
using ASM_Day11.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASM_Day11.Services
{
    public class CategoryService : ICategoryService
    {
        private ProductContext _context;
        public CategoryService(ProductContext context)
        {
            _context = context;
        }
        public async Task AddCategory(CategoryDTO category)
        {
            var item = new Category
            {
                CategoryName = category.CategoryName
            };
            await _context.Categories.AddAsync(item);
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteCategory(int id)
        {
            var item = _context.Categories.FirstOrDefault(m => m.CategoryId == id);
            if (item != null)
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var item = await _context.Categories.FindAsync(id);
            if(item != null)
            {
                return item;
            }
            return null;
        }

        public async Task UpdateCategory(int id, CategoryDTO category)
        {
            var item = await _context.Categories.FindAsync(id);
            if (item != null)
            {
                item.CategoryName = category.CategoryName;
                _context.Categories.Update(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
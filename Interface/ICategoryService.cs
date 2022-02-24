using ASM_Day11.DTO;
using ASM_Day11.Entities;

namespace ASM_Day11.Interface
{
    public interface ICategoryService
    {
        Task AddCategory(CategoryDTO category);
        Task UpdateCategory(int id, CategoryDTO category);
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task DeleteCategory(int id);
    }
}
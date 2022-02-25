using ASM_Day11.DTO;
using ASM_Day11.Entities;

namespace ASM_Day11.Interfaces
{
    public interface IProductService
    {
        Task AddProduct(ProductDTO product);
        Task UpdateProduct(int id, ProductDTO product);
        //Task DeleteProduct(int id);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task DeleteProduct(int id);
    }
}
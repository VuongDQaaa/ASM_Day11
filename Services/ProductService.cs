using ASM_Day11.DB;
using ASM_Day11.DTO;
using ASM_Day11.Entities;
using ASM_Day11.Interface;
using Microsoft.EntityFrameworkCore;

namespace ASM_Day11.Services
{
    public class ProductService : IProductService
    {
        private ProductContext _context;
        public ProductService(ProductContext context)
        {
            _context = context;
        }

        public async Task AddProduct(ProductDTO product)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var item = new Product
                {
                    ProductName = product.ProductName,
                    Manufacture = product.Manufacture,
                    CategoryId = product.CategoryId
                };
                await _context.AddAsync(item);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteProduct(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var item = await _context.Products.FindAsync(id);
                if (item != null)
                {
                    _context.Remove(item);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            var item = await _context.Products.FindAsync(id);
            if (item != null)
            {
                return item;
            }
            return null;
        }

        public async Task UpdateProduct(int id, ProductDTO dto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var foundCategory = await _context.Categories.FindAsync(dto.CategoryId);
                if (foundCategory != null)
                {
                    var item = await _context.Products.FindAsync(id);
                    if (item != null)
                    {
                        item.ProductName = dto.ProductName;
                        item.Manufacture = dto.Manufacture;
                        item.CategoryId = dto.CategoryId;
                        _context.Products.Update(item);
                        await _context.SaveChangesAsync();

                        await transaction.CommitAsync();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
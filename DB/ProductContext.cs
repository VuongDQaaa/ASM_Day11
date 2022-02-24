using ASM_Day11.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASM_Day11.DB
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> option) : base(option) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                        .HasMany<Product>(p => p.Products)
                        .WithOne(c => c.Category)
                        .HasForeignKey(s => s.CategoryId)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "book"
                }
    );
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, CategoryId = 1, ProductName = "Hamlet", Manufacture = "HN" },
                new Product { ProductId = 2, CategoryId = 1, ProductName = "ABC", Manufacture = "HN" },
                new Product { ProductId = 3, CategoryId = 1, ProductName = "EFG", Manufacture = "HN" }
            );
        }
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using Udemy.WebApi.Data;

namespace Udemy.WebApi.Controllers.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Kategori-1",
            });

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id=1,
                Name="Bilgisayar",
                CreatedDate = DateTime.Now.AddDays(-3),
                ImagePath = "www.asd.com",
                Price = 15000,
                Stock = 134,
                CategoryId = 1,
            });
        }
    }
}

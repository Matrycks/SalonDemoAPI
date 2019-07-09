using Microsoft.EntityFrameworkCore;
using SalonAPI.Data.Interfaces;

namespace SalonAPI.Data
{
    public class SalonContext : DbContext, ISalonDbContext
    {
        public DbSet<UserDto> Users {get;set;}
        public DbSet<ProductDto> Products {get;set;}
        public DbSet<CartDto> Carts {get;set;}
        public DbSet<CartItemDto> CartItems {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=salon.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDto>().HasData(new ProductDto
            {
                ProductId = 1,
                Name = "Black Vanilla Conditioner",
                Price = 24.00,
                Description = "This conditioner is one of the best out! A quick tip for this product is to put on as much as possible and work it through the hair strands."
            }, new ProductDto
            {
                ProductId = 2,
                Name = "Jet Black Clip-In Extensions",
                Price = 81.00,
                Description = "Add length and volume to your hair with the 20″ Jet Black Clip-In Hair Extensions. Quickly clip in a new look and style straight or with curls."
            }, new ProductDto
            {
                ProductId = 3,
                Name = "Brazilian Straight Hair",
                Price = 29.99,
                Description = "Brazilian Silky Straight Hair Extensions are true to length with the ability to color and style to perfection. With our wholesale straight bundles starting at just $29.99, it is hard to beat our quality and price. Maintenance is simple and silky straight is perfect for a bob or long lengths up to 32."
            });

            modelBuilder.Entity<UserDto>().HasData(new UserDto
            {
                UserId = 1,
                Firstname = "Ashley",
                Lastname = "Walter",
                Email = "janeeharris@hotmail.com"
            });
        }

        public int SaveContextChanges()
        {
            return this.SaveChanges();
        }
    }
}
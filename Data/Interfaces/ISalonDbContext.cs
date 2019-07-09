using Microsoft.EntityFrameworkCore;

namespace SalonAPI.Data.Interfaces
{
    public interface ISalonDbContext
    {
         DbSet<ProductDto> Products {get;set;}
         DbSet<UserDto> Users {get;set;}
         DbSet<CartDto> Carts {get;set;}
         DbSet<CartItemDto> CartItems {get;set;}
         int SaveContextChanges();
    }
}
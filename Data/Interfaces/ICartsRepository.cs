using System.Collections.Generic;

namespace SalonAPI.Data.Interfaces
{
    public interface ICartsRepository : IRepository<CartDto>
    {
         CartItemDto AddItem(CartItemDto item);
         void DeleteItem(int cartItemId);
         IEnumerable<CartItemDto> GetItems(int cartId);
         CartDto GetUserCart(int userId);
         CartItemDto UpdateItem(CartItemDto item);
    }
}
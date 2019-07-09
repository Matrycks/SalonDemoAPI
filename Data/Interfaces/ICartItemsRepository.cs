using System.Linq;
namespace SalonAPI.Data.Interfaces
{
    public interface ICartItemsRepository : IRepository<CartItemDto>
    {
         IQueryable<CartItemDto> GetByCartId(int cartId);
    }
}
using System.Collections.Generic;
using System.Linq;
using SalonAPI.Data.Interfaces;

namespace SalonAPI.Data.Repositories
{
    public class CartItemsRepository : ICartItemsRepository
    {
        private readonly ISalonDbContext _dbContext;
        public CartItemsRepository(ISalonDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public CartItemDto Add(CartItemDto item)
        {
            var nItem = this._dbContext.CartItems.Add(item).Entity;
            this._dbContext.SaveContextChanges();
            return nItem;
        }

        public void Delete(int entityId)
        {
            this._dbContext.CartItems.Remove(this._dbContext.CartItems.Find(entityId));
            this._dbContext.SaveContextChanges();
        }

        public IQueryable<CartItemDto> Get()
        {
            return this._dbContext.CartItems;
        }

        public CartItemDto Get(int entityId)
        {
            return this._dbContext.CartItems.Find(entityId);
        }

        public IQueryable<CartItemDto> GetByCartId(int cartId)
        {
            return this._dbContext.CartItems.Where(x=>x.CartId==cartId);
        }

        public CartItemDto Update(CartItemDto entity)
        {
            var uItem = this._dbContext.CartItems.Update(entity).Entity;
            this._dbContext.SaveContextChanges();
            return uItem;
        }
    }
}
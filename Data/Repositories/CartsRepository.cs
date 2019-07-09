using System.Collections.Generic;
using System.Linq;
using SalonAPI.Data.Interfaces;

namespace SalonAPI.Data.Repositories
{
    public class CartsRepository : ICartsRepository
    {
        private readonly ISalonDbContext _dbContext;
        private readonly ICartItemsRepository _cartItemsRepo;
        public CartsRepository(ISalonDbContext dbContext, ICartItemsRepository cartItemsRepo)
        {
            this._dbContext = dbContext;
            this._cartItemsRepo = cartItemsRepo;
        }

        public CartDto Add(CartDto entity)
        {
            var nCart = this._dbContext.Carts.Add(entity).Entity;
            return nCart;
        }

        public CartItemDto AddItem(CartItemDto item)
        {
            var nItem = this._cartItemsRepo.Add(item);
            return nItem;
        }

        public void Delete(int entityId)
        {
            this._dbContext.Carts.Remove(this._dbContext.Carts.Find(entityId));
            this._dbContext.SaveContextChanges();
        }

        public void DeleteItem(int cartItemId)
        {
            this._cartItemsRepo.Delete(cartItemId);
        }
        public IQueryable<CartDto> Get()
        {
            return this._dbContext.Carts;
        }

        public CartDto Get(int entityId)
        {
            return this._dbContext.Carts.Find(entityId);
        }

        public IEnumerable<CartItemDto> GetItems(int cartId)
        {
            return this._cartItemsRepo.GetByCartId(cartId);
        }

        public CartDto GetUserCart(int userId)
        {
            return this._dbContext.Carts.Single(x=>x.UserId==userId);
        }

        public CartDto Update(CartDto entity)
        {
            throw new System.NotImplementedException();
        }

        public CartItemDto UpdateItem(CartItemDto item)
        {
            return this._cartItemsRepo.Update(item);
        }
    }
}
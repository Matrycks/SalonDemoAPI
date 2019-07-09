using System.Collections.Generic;
using System.Linq;
using SalonAPI.Data.Interfaces;

namespace SalonAPI.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ISalonDbContext _dbContext;
        public ProductsRepository(ISalonDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public ProductDto Add(ProductDto entity)
        {
            var nProduct = this._dbContext.Products.Add(entity).Entity;
            this._dbContext.SaveContextChanges();
            return nProduct;
        }

        public void Delete(int entityId)
        {
            this._dbContext.Products.Remove(this._dbContext.Products.Find(entityId));
            this._dbContext.SaveContextChanges();
        }

        public IQueryable<ProductDto> Get()
        {
            return this._dbContext.Products;
        }

        public ProductDto Get(int entityId)
        {
            return this._dbContext.Products.Find(entityId);
        }

        public IQueryable<ProductDto> GetByCategories(string[] categories)
        {
            //TODO
            throw new System.NotImplementedException();
        }

        public ProductDto Update(ProductDto entity)
        {
            var uProduct = this._dbContext.Products.Update(entity).Entity;
            this._dbContext.SaveContextChanges();
            return uProduct;
        }
    }
}
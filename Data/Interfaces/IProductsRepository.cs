using System.Linq;
namespace SalonAPI.Data.Interfaces
{
    public interface IProductsRepository : IRepository<ProductDto>
    {
         IQueryable<ProductDto> GetByCategories(string[] categories);
    }
}
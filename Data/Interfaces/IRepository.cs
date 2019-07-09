using System.Linq;
namespace SalonAPI.Data.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        T Add(T entity);
         void Delete(int entityId);
         IQueryable<T> Get();
         T Get(int entityId);
         T Update(T entity);
    }
}
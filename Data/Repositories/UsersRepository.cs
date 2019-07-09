using System.Collections.Generic;
using System.Linq;
using SalonAPI.Data.Interfaces;

namespace SalonAPI.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ISalonDbContext _dbContext;
        public UsersRepository(ISalonDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public UserDto Add(UserDto entity)
        {
            var nUser = this._dbContext.Users.Add(entity).Entity;
            this._dbContext.SaveContextChanges();
            return nUser;
        }

        public void Delete(int entityId)
        {
            this._dbContext.Users.Remove(this._dbContext.Users.Find(entityId));
            this._dbContext.SaveContextChanges();
        }

        public IQueryable<UserDto> Get()
        {
            return this._dbContext.Users;
        }

        public UserDto Get(int entityId)
        {
            return this._dbContext.Users.Find(entityId);
        }

        public UserDto Update(UserDto entity)
        {
            var uUser = this._dbContext.Users.Update(entity).Entity;
            this._dbContext.SaveContextChanges();
            return uUser;
        }
    }
}
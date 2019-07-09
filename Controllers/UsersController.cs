using Microsoft.AspNetCore.Mvc;
using SalonAPI.Data;
using SalonAPI.Data.Interfaces;

namespace SalonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepo;
        public UsersController(IUsersRepository usersRepo)
        {
            this._usersRepo = usersRepo;
        }

        [HttpDelete]
        public ActionResult Delete(int userId)
        {
            this._usersRepo.Delete(userId);
            return Ok();
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(this._usersRepo.Get());
        }

        [HttpGet("{userId}")]
        public ActionResult Get(int userId)
        {
            return Ok(this._usersRepo.Get(userId));
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserDto user)
        {
            var nUser = this._usersRepo.Add(user);
            return Ok(nUser);
        }

        [HttpPatch]
        public ActionResult Update([FromBody] UserDto user)
        {
            var uUser = this._usersRepo.Update(user);
            return Ok(uUser);
        }
    }
}
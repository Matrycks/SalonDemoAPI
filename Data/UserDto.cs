using System.ComponentModel.DataAnnotations;
using SalonAPI.Data.Interfaces;

namespace SalonAPI.Data
{
    public class UserDto : IEntity
    {
        [Key]
        public int UserId {get;set;}
        public string Firstname {get;set;}
        public string Lastname {get;set;}
        public string Email {get;set;}
        public string Username
        {
            get{ return this.Email.Substring(0, this.Email.LastIndexOf('@')); }
        }
    }
}
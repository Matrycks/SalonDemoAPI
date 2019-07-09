using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SalonAPI.Data.Interfaces;

namespace SalonAPI.Data
{
    public class CartDto : IEntity
    {
        [Key]
        public int CartId {get;set;}
        public int UserId {get;set;}
        public double Total {get;set;}
        public ICollection<CartItemDto> Items {get;set;}
    }
}
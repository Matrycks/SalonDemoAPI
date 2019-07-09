using System.ComponentModel.DataAnnotations;
using SalonAPI.Data.Interfaces;

namespace SalonAPI.Data
{
    public class CartItemDto : IEntity
    {
        [Key]
        public int CartItemId {get;set;}
        public int UserId {get;set;}
        public int ProductId {get;set;}

        //NOTE: this will be updated by worker process when product pricing has changed
        public double ProductPrice {get;set;}
        public int Quantity {get;set;}

        public int CartId {get;set;}
        public CartDto Cart {get;set;}

    }
}
using System.ComponentModel.DataAnnotations;
using SalonAPI.Data.Interfaces;

namespace SalonAPI.Data
{
    public class ProductDto : IEntity
    {
        [Key]
        public int ProductId {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public double Price {get;set;}
    }
}
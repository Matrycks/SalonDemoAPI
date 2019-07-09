using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SalonAPI.Data;
using SalonAPI.Data.Interfaces;

namespace SalonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartsRepository _cartsRepo;
        private readonly IProductsRepository _productsRepo;
        public CartsController(ICartsRepository cartsRepo, IProductsRepository productsRepo)
        {
            this._cartsRepo = cartsRepo;
            this._productsRepo = productsRepo;
        }

        [HttpPost]
        [Route("Items")]
        public ActionResult AddItem([FromBody] CartItemDto item)
        {
            CartItemDto responseItem = null;
            ProductDto product = this._productsRepo.Get(item.ProductId);

            var cartItem = this._cartsRepo.GetItems(item.CartId).SingleOrDefault(x=>x.ProductId==item.ProductId) ?? null;
            if(cartItem != null)
            {
                cartItem.Quantity = cartItem.Quantity + 1;
                cartItem.ProductPrice = product.Price;

                var uItem = this._cartsRepo.UpdateItem(cartItem);
                responseItem = uItem;
            }
            else if(item.CartId <= 0 && this._cartsRepo.Get().SingleOrDefault(x=>x.UserId==item.UserId) == null)
            {
                var cart = this._cartsRepo.Add(new CartDto{ UserId = item.UserId });
                item.CartId = cart.CartId;
                item.ProductPrice = product.Price;

                responseItem = this._cartsRepo.AddItem(item);
            }
            else if(this._cartsRepo.Get(item.CartId) == null)
                return StatusCode(400, string.Format("CartId: {0} doesn't exist", item.CartId));
            else
            {
                item.ProductPrice = product.Price;
                responseItem = this._cartsRepo.AddItem(item);
            }
            return Ok(responseItem);
        }

        [HttpDelete]
        [Route("item/{itemId}")]
        public ActionResult DeleteItem(int itemId)
        {
            this._cartsRepo.DeleteItem(itemId);
            return Ok();
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(this._cartsRepo.Get());
        }

        [HttpGet("{cartId}")]
        public ActionResult Get(int cartId)
        {
            var cart = this._cartsRepo.Get(cartId);
            cart.Total = this._cartsRepo.GetItems(cartId).Sum(x=>x.ProductPrice*x.Quantity);
            return Ok(cart);
        }

        [HttpGet]
        [Route("{cartId}/Items")]
        public ActionResult GetCartItems(int cartId)
        {
            return Ok(this._cartsRepo.GetItems(cartId));
        }

        [HttpGet]
        [Route("User/{userId}")]
        public ActionResult GetUserCart(int userId)
        {
            return Ok(this._cartsRepo.Get().FirstOrDefault(x=>x.UserId==userId));
        }
    }
}
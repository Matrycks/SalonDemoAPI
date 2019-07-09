using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SalonAPI.Data;
using SalonAPI.Data.Interfaces;

namespace SalonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepo;
        public ProductsController(IProductsRepository productsRepo)
        {
            this._productsRepo = productsRepo;
        }

        [HttpPost]
        public ActionResult Add([FromBody] ProductDto product)
        {
            var nProduct = this._productsRepo.Add(product);
            return Ok(nProduct);
        }

        [HttpDelete]
        public ActionResult Delete(int productId)
        {
            this._productsRepo.Delete(productId);
            return Ok();
        }

        [HttpGet]
        public ActionResult Get()
        {
            var productList = this._productsRepo.Get().ToList();
            return Ok(productList);
        }

        [HttpGet("{productId}")]
        public ActionResult Get(int productId)
        {
            var product = this._productsRepo.Get(productId);
            return Ok(product);
        }

        [HttpPatch]
        public ActionResult Update([FromBody] ProductDto product)
        {
            var uProduct = this._productsRepo.Update(product);
            return Ok(uProduct);
        }
    }
}
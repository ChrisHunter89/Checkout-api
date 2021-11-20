using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Checkout_api.Models;

namespace Checkout_api.Controllers
{
    [ApiController]
    [Route("ShoppingBasket")]
    public class ShoppingBasketController : Controller
    {
        [HttpPost]
        [Route("Checkout")]
        public IActionResult Post(Basket basket)
        {
            var currentBasket = Json(basket);
            return Ok(currentBasket);
        }
    }
}

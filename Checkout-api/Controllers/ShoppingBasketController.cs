using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Checkout_api.Models;
using Checkout_api.Interfaces;

namespace Checkout_api.Controllers
{

    [ApiController]
    [Route("ShoppingBasket")]
    public class ShoppingBasketController : Controller
    {
        private readonly ICheckoutService _checkoutService;

        public ShoppingBasketController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_checkoutService.GetAvailableItems());
        }



        [HttpPost]
        [Route("Checkout")]
        public IActionResult Post([FromBody]Basket basket)
        {
            var currentBasket = Json(basket);
            return Ok(currentBasket);
        }
    }
}
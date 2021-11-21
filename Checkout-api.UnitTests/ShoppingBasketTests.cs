using Xunit;
using Checkout_api.Controllers;
using Checkout_api.Services;
using Checkout_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Checkout_api.Models;

namespace Checkout_api.UnitTests
{
    public class ShoppingBasketTests
    {
        private readonly ShoppingBasketController shoppingBasketController;


        private readonly ICheckoutService _checkoutService;

        public ShoppingBasketTests()
        {
            _checkoutService = new CheckoutService();
            shoppingBasketController = new ShoppingBasketController(_checkoutService);
        }

        [Fact]
        public void GetAvailableItems_ReturnsOkActionResult()
        {
            // Act
            var result = shoppingBasketController.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        [Fact]
        public void GetAvailableItems_ReturnsAllAvailableItems()
        {
            // Act
            var result = shoppingBasketController.Get() as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Item>>(result.Value);
            Assert.Equal(4, items.Count);
        }
    }
}
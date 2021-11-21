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

        private static Item itemA = new Item { Name = "A", UnitPrice = 10 };
        private static Item itemB = new Item { Name = "B", UnitPrice = 15 };
        private static Item itemC = new Item { Name = "C", UnitPrice = 40 };
        private static Item itemD = new Item { Name = "D", UnitPrice = 55 };

        private readonly Basket singleItemBasket = new Basket
        {
            Items = new List<Item> { itemA }
        };

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
            var items = Assert.IsType<List<Item>>(result?.Value);
            Assert.Equal(4, items.Count);
        }

        [Fact]
        public void Checkout_WithValidItems_ReturnOkActionResult()
        {
            // Act
            var result = shoppingBasketController.CheckoutItems(singleItemBasket) as OkObjectResult;

            // Assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        [Fact]
        public void Checkout_WithSingleItem_BasketTotalOf10()
        {
            // Act
            var result = shoppingBasketController.CheckoutItems(singleItemBasket) as OkObjectResult;

            // Assert
            var basket = Assert.IsType<Basket>(result?.Value);
            Assert.Equal(10, basket.Total);
        }
    }
}
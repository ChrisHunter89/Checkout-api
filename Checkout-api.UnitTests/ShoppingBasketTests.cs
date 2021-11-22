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

        private static Item itemA = new Item { Name = "A" };
        private static Item itemB = new Item { Name = "B" };
        private static Item itemC = new Item { Name = "C" };
        private static Item itemD = new Item { Name = "D" };


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

        #region Single Item Type Tests
        [Fact]
        public void Checkout_WithValidItems_ReturnOkActionResult()
        {
            // Arrange
            itemA.QunatityRequired = 1;
            Basket basket = new Basket { Items = new List<Item> { itemA } };

            // Act
            var result = shoppingBasketController.CheckoutItems(basket) as OkObjectResult;

            // Assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        [Fact]
        public void Checkout_WithSingleItemA_BasketTotalOf10()
        {
            // Arrange
            itemA.QunatityRequired = 1;
            Basket basket = new Basket { Items = new List<Item> { itemA } };

            // Act
            var result = shoppingBasketController.CheckoutItems(basket) as OkObjectResult;

            // Assert
            var resultBasket = Assert.IsType<Basket>(result?.Value);
            Assert.Equal(10, resultBasket.Total);
        }

        [Fact]
        public void Checkout_WithThreeOfItemA_BasketTotalOf30()
        {
            // Arrange
            itemA.QunatityRequired = 3;
            Basket basket = new Basket { Items = new List<Item> { itemA } };

            // Act
            var result = shoppingBasketController.CheckoutItems(basket) as OkObjectResult;

            // Assert
            var resultBasket = Assert.IsType<Basket>(result?.Value);
            Assert.Equal(30, resultBasket.Total);
        }
        #endregion

        #region Multiple Item Types Tests
        [Fact]
        public void Checkout_WithMultipleItems_OkActionResult()
        {
            // Arrange
            itemA.QunatityRequired = 3;
            itemB.QunatityRequired = 1;
            Basket basket = new Basket
            {
                Items = new List<Item> { itemA, itemB },
            };

            // Act
            var result = shoppingBasketController.CheckoutItems(basket) as OkObjectResult;

            // Assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        [Fact]
        public void Checkout_WithThreeItemAOneItemB_BasketTotalOf45()
        {
            // Arrange
            itemA.QunatityRequired = 3;
            itemB.QunatityRequired = 1;
            Basket basket = new Basket
            {
                Items = new List<Item> { itemA, itemB },
            };

            // Act
            var result = shoppingBasketController.CheckoutItems(basket) as OkObjectResult;

            // Assert
            var resultBasket = Assert.IsType<Basket>(result?.Value);
            Assert.Equal(45, resultBasket.Total);
        }


        [Fact]
        public void Checkout_WithTwoOfEachItem_BasketTotalOf45()
        {
            // Arrange
            itemA.QunatityRequired = 2;
            itemB.QunatityRequired = 2;
            itemC.QunatityRequired = 2;
            itemD.QunatityRequired = 2;
            Basket basket = new Basket
            {
                Items = new List<Item> { itemA, itemB, itemC, itemD },
            };

            // Act
            var result = shoppingBasketController.CheckoutItems(basket) as OkObjectResult;

            // Assert
            var resultBasket = Assert.IsType<Basket>(result?.Value);
            Assert.Equal(240, resultBasket.Total);
        }
        #endregion

        #region Promotion Tests
        [Fact]
        public void Checkout_With3For40ItemBPromotion_BasketTotalOf40()
        {
            // Arrange
            itemB.QunatityRequired = 3;
            Basket basket = new Basket
            {
                Items = new List<Item> { itemB },
            };

            // Act
            var result = shoppingBasketController.CheckoutItems(basket) as OkObjectResult;

            // Assert
            var resultBasket = Assert.IsType<Basket>(result?.Value);
            Assert.Equal(40, resultBasket.Total);
        }
        #endregion
    }
}
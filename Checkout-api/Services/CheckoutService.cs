using Checkout_api.Models;
using Checkout_api.Interfaces;

namespace Checkout_api.Services
{
    public class CheckoutService : ICheckoutService
    {
        private List<Item> availableItems = new List<Item> { 
            new Item { Name = "A", UnitPrice = 10 },
            new Item { Name = "B", UnitPrice = 15 },
            new Item { Name = "C", UnitPrice = 40 },
            new Item { Name = "D", UnitPrice = 55 }
        };

        private Basket basket { get; set; }

        public CheckoutService()
        {
        }

        public List<Item> GetAvailableItems()
        {
            throw new NotImplementedException();
        }

        public Basket CalculateBasket()
        {
            throw new NotImplementedException();
        }
    }
}

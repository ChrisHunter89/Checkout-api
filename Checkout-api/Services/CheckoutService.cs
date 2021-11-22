using Checkout_api.Models;
using Checkout_api.Interfaces;
using Checkout_api.Data;

namespace Checkout_api.Services
{
    public class CheckoutService : ICheckoutService
    {

        private Basket basket { get; set; }
        public CheckoutService()
        {
        }

        public List<Item> GetAvailableItems()
        {
            return Stock.AvailableItems;
        }

        public Basket CalculateBasket(Basket basket)
        {
            if (basket == null || basket.Items == null) return null;

            foreach (var basketItem in basket.Items)
            {
                var unitPrice = Stock.AvailableItems.Where(si => si.Name == basketItem.Name).Select(i => i.UnitPrice).FirstOrDefault();
                basket.Total += unitPrice * basketItem.QunatityRequired;
            }

            return basket;
        }
    }
}

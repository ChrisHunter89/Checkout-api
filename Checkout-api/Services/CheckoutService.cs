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
            throw new NotImplementedException();
        }
    }
}

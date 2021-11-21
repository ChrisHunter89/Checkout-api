using Checkout_api.Models;

namespace Checkout_api.Interfaces
{
    public interface ICheckoutService
    {
        List<Item> GetAvailableItems();
        Basket CalculateBasket();
    }
}

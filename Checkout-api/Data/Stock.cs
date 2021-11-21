using Checkout_api.Models;

namespace Checkout_api.Data
{
    public static class Stock
    {
        public static readonly List<Item> AvailableItems = new List<Item> {
            new Item { Name = "A", UnitPrice = 10 },
            new Item { Name = "B", UnitPrice = 15 },
            new Item { Name = "C", UnitPrice = 40 },
            new Item { Name = "D", UnitPrice = 55 }
        };
    }
}

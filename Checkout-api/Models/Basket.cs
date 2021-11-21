using Checkout_api.Models;

namespace Checkout_api
{
    public class Basket
    {
        public List<Item>? Items { get; set; }
        public decimal Total { get; set; }
    }
}

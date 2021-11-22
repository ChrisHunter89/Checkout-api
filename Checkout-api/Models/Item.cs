namespace Checkout_api.Models
{
    public class Item
    {
        public string? Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int QunatityRequired { get; set; }
        delegate Func<decimal> ApplyPromotion(decimal quantity);
    }
}

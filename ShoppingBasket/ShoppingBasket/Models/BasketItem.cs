using ShoppingBasket.Common.Models;

namespace ShoppingBasket.Models
{
    public class BasketItem : IBasketItem
    {
        public IItem Item { get; set; }
        public IPriceListItem PriceListItem { get; set; }
        public int Quantity { get; set; }

        public bool Equals(BasketItem other)
        {
            return Item.ID == other.Item.ID;
        }

        public bool Equals(IBasketItem other)
        {
            return Item.ID == other.Item.ID;
        }
    }
}

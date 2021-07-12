using System;

namespace ShoppingBasket.Common.Models
{
    public interface IBasketItem : IEquatable<IBasketItem>
    {
        IItem Item { get; set; }
        IPriceListItem PriceListItem { get; set; }
        int Quantity { get; set; }
    }
}

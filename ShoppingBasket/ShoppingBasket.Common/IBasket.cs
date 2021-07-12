using ShoppingBasket.Common.Models;
using System.Collections.Generic;

namespace ShoppingBasket.Common
{
    public interface IBasket
    {
        void AddItem(IBasketItem item);
        void RemoveItem(IBasketItem item);
        IEnumerable<IBasketItem> Items();
    }
}

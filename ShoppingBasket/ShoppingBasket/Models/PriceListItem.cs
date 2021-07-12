using ShoppingBasket.Common.Models;
using System;

namespace ShoppingBasket.Models
{
    public class PriceListItem : IPriceListItem
    {
        public IItem Item { get; set; }
        public decimal Price { get; set; }
        public IPriceList PriceList { get; set; }
        public Guid ID { get; set; }
    }
}

using ShoppingBasket.Common.Models;
using System;
using System.Collections.Generic;

namespace ShoppingBasket.Models
{
    internal class TotalModel
    {
        public Guid ID { get; set; }
        public IEnumerable<IItem> Items { get; set; }
        public int Quantity { get; set; }
        public IPriceListItem PriceListItem { get; set; }
        public IDiscount Discount { get; set; }
        public bool IsInDiscount { get; set; }
    }
}

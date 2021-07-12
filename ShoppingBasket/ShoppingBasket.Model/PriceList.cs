using System;
using System.Collections.Generic;

namespace ShoppingBasket.Model
{
    public class PriceList
    {
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public IEnumerable<PriceListItem> PriceListItems { get; set; }
        public bool Active { get; set; }
        public IEnumerable<Discount> Discounts { get; set; }

    }
}

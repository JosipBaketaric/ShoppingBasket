using ShoppingBasket.Common.Models;
using System;
using System.Collections.Generic;

namespace ShoppingBasket.Models
{
    public class PriceList : IPriceList
    {
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public IEnumerable<IPriceListItem> PriceListItems { get; set; }
        public Guid ID { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ShoppingBasket.Common.Models
{
    public interface IPriceList : IModel
    {
        DateTime ValidFrom { get; set; }
        DateTime ValidTo { get; set; }
        IEnumerable<IPriceListItem> PriceListItems { get; set; }

    }
}

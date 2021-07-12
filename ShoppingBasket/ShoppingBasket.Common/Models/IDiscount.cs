using System;
using System.Collections.Generic;

namespace ShoppingBasket.Common.Models
{
    public interface IDiscount : IModel
    {
        string Description { get; set; }
        DateTime DateFrom { get; set; }
        DateTime DateTo { get; set; }
        decimal Rate { get; set; }

        IEnumerable<IItem> Selector(IEnumerable<IItem> items);
        IEnumerable<(IItem, IDiscount)> Apply(IEnumerable<IItem> items);
        bool IsDiscountApplicable(IEnumerable<IItem> items);
    }
}

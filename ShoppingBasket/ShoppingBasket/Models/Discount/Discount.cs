using ShoppingBasket.Common.Models;
using System;
using System.Collections.Generic;

namespace ShoppingBasket.Models.Discount
{
    /// <summary>
    /// Base Discount class
    /// </summary>
    public abstract class Discount : IDiscount
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal Rate { get; set; }

        public abstract bool IsDiscountApplicable(IEnumerable<IItem> items);

        public abstract IEnumerable<IItem> Selector(IEnumerable<IItem> items);

        public abstract IEnumerable<(IItem, IDiscount)> Apply(IEnumerable<IItem> items);
    }
}

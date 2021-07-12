using ShoppingBasket.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket.Models.Discount
{
    /// <summary>
    /// One item discounted
    /// </summary>
    public class OneItemDiscount : Discount
    {
        public Guid ItemID { get; set; }

        public override IEnumerable<(IItem, IDiscount)> Apply(IEnumerable<IItem> items)
        {
            var filteredItems = Selector(items);

            return filteredItems
                .Select(x => (x, (IDiscount)this))
                .ToList();
        }

        public override bool IsDiscountApplicable(IEnumerable<IItem> items)
        {
            return Selector(items).Any();
        }

        public override IEnumerable<IItem> Selector(IEnumerable<IItem> items)
        {
            return items
                .Where(x => x.ID == ItemID)
                .ToList();
        }
    }
}

using ShoppingBasket.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ShoppingBasket.Models.Discount
{
    /// <summary>
    /// Buy N of the same items and get one on discount
    /// </summary>
    public class NItemDiscount : Discount
    {
        public Guid ItemID { get; set; }
        public int QuantityClause { get; set; }

        public override IEnumerable<(IItem, IDiscount)> Apply(IEnumerable<IItem> items)
        {
            var filteredItems = Selector(items);
            IList<(IItem, IDiscount)> result = new List<(IItem, IDiscount)>();

            for (int i = 0; i < filteredItems.Count(); i++)
            {
                result.Add((filteredItems.ElementAt(i), this));
            }

            var resultItems = items
                .Where(x => x.ID == ItemID && !filteredItems.Contains(x))
                .ToList();

            foreach(var conditionItems in resultItems)
            {
                result.Add((conditionItems, null));
            }

            return result;

        }

        public override bool IsDiscountApplicable(IEnumerable<IItem> items)
        {
            return items
                .Where(x => x.ID == ItemID)
                .Count() >= QuantityClause;
        }

        public override IEnumerable<IItem> Selector(IEnumerable<IItem> items)
        {
            var resultItems = items
                .Where(x => x.ID == ItemID)
                .ToList();

            var cnt = resultItems.Count();

            var numberOfGroups = Convert.ToInt32(Math.Floor((decimal)(cnt / QuantityClause)));

            return resultItems
                .Take(numberOfGroups)
                .ToList();
        }
    }
}

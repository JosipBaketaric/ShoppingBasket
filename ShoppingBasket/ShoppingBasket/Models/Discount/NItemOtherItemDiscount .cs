using ShoppingBasket.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ShoppingBasket.Models.Discount
{
    /// <summary>
    /// Buy N of the same items and get another item on discount
    /// </summary>
    public class NItemOtherItemDiscount : Discount
    {
        public Guid ItemID { get; set; }
        public Guid DiscountClauseItemID { get; set; }

        public int QuantityClause { get; set; }

        public override IEnumerable<(IItem, IDiscount)> Apply(IEnumerable<IItem> items)
        {
            var filteredItems = Selector(items);
            IList<(IItem, IDiscount)> result = new List<(IItem, IDiscount)>();

            for (int i = 0; i < filteredItems.Count(); i++)
            {
                if (filteredItems.ElementAt(i).ID == ItemID)
                {
                    result.Add((filteredItems.ElementAt(i), this));
                }
                else
                {
                    result.Add((filteredItems.ElementAt(i), null));
                }
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
                .Count() >= 1
                &&
                items
                .Where(x => x.ID == DiscountClauseItemID)
                .Count() >= QuantityClause
                ;
        }

        public override IEnumerable<IItem> Selector(IEnumerable<IItem> items)
        {
            var resultItems = items
                .Where(x => x.ID == ItemID || x.ID == DiscountClauseItemID)
                .ToList();

            var cnt = resultItems.Count();

            var numberOfGroups = Convert.ToInt32(Math.Floor((decimal)( (cnt) / (QuantityClause + 1))));

            var discountClauseItems = resultItems
                .Where(x => x.ID == DiscountClauseItemID)
                .Take(numberOfGroups)
                .ToList();

            var discountedItems = resultItems
                .Where(x => x.ID == ItemID)
                .Take(numberOfGroups)
                .ToList();

            return discountClauseItems
                .ToList()
                .Concat(discountedItems)
                .ToList();
        }
    }
}

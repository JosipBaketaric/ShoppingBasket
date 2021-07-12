using ShoppingBasket.Common;
using ShoppingBasket.Common.Models;
using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class TotalCalculator : ITotalCalculator
    {
        public decimal Calculate(IBasket basket, IEnumerable<IDiscount> discounts)
        {
            var itemsInDiscountList = new List<(IItem Item, IDiscount Discount)>();

            var items = basket.Items()
                .Where(x => x.Item != null)
                .Select(x => new TotalModel()
                {
                    ID = x.Item.ID,
                    Items = BreakDownItems(x),
                    Quantity = x.Quantity,
                    PriceListItem = x.PriceListItem
                })

                .ToList();

            foreach (var discount in discounts)
            {
                var baseItems = items
                    .SelectMany(x => x.Items)
                    .ToList();

                if (!discount.IsDiscountApplicable(baseItems))
                {
                    continue;
                }

                var discountedItems = discount.Apply(baseItems);

                itemsInDiscountList.AddRange(discountedItems);

                var itemsToRemove = discountedItems
                    .Select(x => x.Item1)
                    .ToList();

                RemoveItems(ref items, itemsToRemove);
            }

            var originalItems = basket.Items();

            var baseTotal = items
                .Select(x => Math.Round(x.PriceListItem.Price, 2))
                .DefaultIfEmpty(0)
                .Sum();

            decimal discountedTotal = 0m;

            foreach (var discountItem in itemsInDiscountList)
            {
                var baseItem = originalItems.FirstOrDefault(x => x.Item.ID == discountItem.Item.ID);
                var discountRate = discountItem.Discount == null ? 1 : 1 - (discountItem.Discount.Rate / 100);

                discountedTotal += Math.Round((baseItem.PriceListItem.Price * discountRate), 2);
            }


            return Math.Round(baseTotal + discountedTotal, 2);
        }

        private IEnumerable<IItem> BreakDownItems(IBasketItem basketItem)
        {
            return Enumerable
                .Range(0, basketItem.Quantity)
                .Select(x => new Item()
                {
                    ID = basketItem.Item.ID,
                    Code = basketItem.Item.Code,
                    Name = basketItem.Item.Name

                })
                .ToList();
        }

        private void RemoveItems(ref List<TotalModel> items, IList<IItem> itemsToRemove)
        {
            foreach (var itemToRemove in itemsToRemove)
            {
                var result = items.FirstOrDefault(x => x.ID == itemToRemove.ID);
                if (result != null && result.Quantity == 1)
                {
                    items.Remove(result);
                }
                else
                {
                    result.Quantity--;
                    result.Items.ToList().Remove(result.Items.FirstOrDefault());
                }
            }
        }

    }
}

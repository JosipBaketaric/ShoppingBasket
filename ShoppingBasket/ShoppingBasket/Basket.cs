using ShoppingBasket.Common;
using ShoppingBasket.Common.Models;
using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class Basket : IBasket
    {
        public Guid ID { get; set; }
        private IList<IBasketItem> ItemList { get; set; }

        public Basket()
        {
            ItemList = new List<IBasketItem>(); 
        }

        public void AddItem(IBasketItem item)
        {
            // Skiped the part with the warehouse and avaible quantity
            var existingItem = ItemList
                .Where(x => x.Equals(item))
                .FirstOrDefault();

            if (existingItem != null)
            {
                existingItem.Quantity++;
                return;
            }

            ItemList.Add(item);
        }

        public void RemoveItem(IBasketItem item)
        {
            var existingItem = ItemList
                .Where(x => x.Equals(item))
                .FirstOrDefault();

            if (existingItem != null)
            {
                existingItem.Quantity--;
                return;
            }

            ItemList.Remove(item);
        }

        // Deep copy so that data in the basket can not be modified from the outside
        public IEnumerable<IBasketItem> Items()
        {
            foreach(var item in ItemList)
            {
                var deepCopyItem = new Item() { ID = item.Item.ID, Code = item.Item.Code, Name = item.Item.Name };
                yield return new BasketItem()
                {
                    Item = deepCopyItem,
                    PriceListItem = new PriceListItem() { ID = item.PriceListItem.ID, Item = deepCopyItem, Price = item.PriceListItem.Price, PriceList = item.PriceListItem.PriceList },
                    Quantity = item.Quantity
                };
            }
        }

    }
}

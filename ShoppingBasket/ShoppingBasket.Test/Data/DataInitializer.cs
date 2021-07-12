using ShoppingBasket.Common;
using ShoppingBasket.Common.Models;
using ShoppingBasket.Models;
using ShoppingBasket.Models.Discount;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket.Test.Data
{
    public class DataInitializer
    {
        private static DataInitializer Instance { get; set; }
        public IBasketFactory BasketFactory 
        {
            get 
            { 
                return new BasketFactory(new Basket());
            }
            set 
            {
                return;
            }
        }
        public IPriceList PriceList { get; set; }
        public IItem Bread { get; set; }
        public IItem Butter { get; set; }
        public IItem Milk { get; set; }
        public ITotalCalculator TotalCalculator { get; set; }
        public IDiscount OneItemDiscount { get; set; }
        public IDiscount NItemDiscount { get; set; }
        public IDiscount NItemOtherItemDiscount { get; set; }


        private DataInitializer()
        {
            InitializeData();
        }

        public static DataInitializer GetInstance()
        {
            if (Instance == null)
            {
                Instance = new DataInitializer();
                Instance.InitializeData();
            }

            return Instance;
        }

        private void InitializeData()
        {
            TotalCalculator = new TotalCalculator();

            InitItems();
            InitPriceList();
            InitDiscounts();
        }

        private void InitItems()
        {
            Bread = new Item()
            {
                ID = Guid.NewGuid(),
                Code = "1",
                Name = "Bread"
            };
            Butter = new Item()
            {
                ID = Guid.NewGuid(),
                Code = "2",
                Name = "Butter"
            };
            Milk = new Item()
            {
                ID = Guid.NewGuid(),
                Code = "3",
                Name = "Milk"
            };
        }

        private void InitPriceList()
        {
            var priceListItems = new List<IPriceListItem>()
            {
                new PriceListItem(){ ID = Guid.NewGuid(), Item = Bread, Price = 1.00m },
                new PriceListItem(){ ID = Guid.NewGuid(), Item = Butter, Price = 0.80m },
                new PriceListItem(){ ID = Guid.NewGuid(), Item = Milk, Price = 1.15m }
            };

            PriceList = new PriceList()
            {
                ID = Guid.NewGuid(),
                ValidFrom = new DateTime(2021, 1, 1),
                ValidTo = new DateTime(2021, 12, 31),
                PriceListItems = priceListItems
            };
        }

        private void InitDiscounts()
        {
            OneItemDiscount = new OneItemDiscount()
            {
                DateFrom = new DateTime(2021, 1, 1),
                DateTo = new DateTime(2021, 12, 31),
                Description = "10% on the milk",
                ID = Guid.NewGuid(),
                ItemID = Milk.ID,
                Rate = 10m
            };

            NItemDiscount = new NItemDiscount()
            {
                DateFrom = new DateTime(2021, 1, 1),
                DateTo = new DateTime(2021, 12, 31),
                Description = "Buy 3 milks and get the 4th milk for free",
                ID = Guid.NewGuid(),
                ItemID = Milk.ID,
                Rate = 100m,
                QuantityClause = 4
            };

            NItemOtherItemDiscount = new NItemOtherItemDiscount()
            {
                DateFrom = new DateTime(2021, 1, 1),
                DateTo = new DateTime(2021, 12, 31),
                Description = "Buy 2 butters and get one bread at 50% off",
                ID = Guid.NewGuid(),
                ItemID = Bread.ID,
                DiscountClauseItemID = Butter.ID,
                Rate = 50m,
                QuantityClause = 2
            };
        }

        public IBasketItem CreateBasketItem(IItem item, int quantity)
        {
            var priceListItem = PriceList.PriceListItems
                .Where(x => x.Item.ID == item.ID)
                .FirstOrDefault();

            return new BasketItem()
            {
                Item = item,
                PriceListItem = priceListItem,
                Quantity = quantity
            };
        }
    }
}

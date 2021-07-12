using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasket.Common.Models;
using ShoppingBasket.Test.Data;
using System;
using System.Collections.Generic;

namespace ShoppingBasket.Test
{
    [TestClass]
    public class BasketTest
    {
        private readonly DataInitializer _dataInitializer;
        public BasketTest()
        {
            _dataInitializer = DataInitializer.GetInstance();
        }
        [TestMethod]
        public void MilkNItemDiscountTest1()
        {
            var basket = _dataInitializer.BasketFactory.GetBasket();
            basket.AddItem(_dataInitializer.CreateBasketItem(_dataInitializer.Milk,4));
            var discounts = new List<IDiscount>() { _dataInitializer.NItemDiscount };

            var result = _dataInitializer.TotalCalculator.Calculate(basket, discounts);

            Assert.AreEqual(3.45m, result);
        }

        [TestMethod]
        public void MilkNItemDiscountTest2()
        {
            var basket = _dataInitializer.BasketFactory.GetBasket();
            basket.AddItem(_dataInitializer.CreateBasketItem(_dataInitializer.Milk, 5));
            var discounts = new List<IDiscount>() { _dataInitializer.NItemDiscount };

            var result = _dataInitializer.TotalCalculator.Calculate(basket, discounts);

            Assert.AreEqual(4.6m, result);
        }

        [TestMethod]
        public void MilkNItemDiscountTest3()
        {
            var basket = _dataInitializer.BasketFactory.GetBasket();
            basket.AddItem(_dataInitializer.CreateBasketItem(_dataInitializer.Milk, 8));
            var discounts = new List<IDiscount>() { _dataInitializer.NItemDiscount };

            var result = _dataInitializer.TotalCalculator.Calculate(basket, discounts);

            Assert.AreEqual(6.90m, result);
        }

        [TestMethod]
        public void RemovingItemSuccess()
        {
            var basket = _dataInitializer.BasketFactory.GetBasket();
            basket.AddItem(_dataInitializer.CreateBasketItem(_dataInitializer.Milk, 8));
            basket.RemoveItem(_dataInitializer.CreateBasketItem(_dataInitializer.Milk, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Item: 2 - Butter doesn't exist in the basket.")]
        public void RemovingItemFail()
        {
            var basket = _dataInitializer.BasketFactory.GetBasket();
            basket.AddItem(_dataInitializer.CreateBasketItem(_dataInitializer.Milk, 8));
            basket.RemoveItem(_dataInitializer.CreateBasketItem(_dataInitializer.Butter, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Item: 2 - Butter doesn't have enough quantity.")]
        public void RemovingItemFailZeroQuantity()
        {
            var basket = _dataInitializer.BasketFactory.GetBasket();
            basket.AddItem(_dataInitializer.CreateBasketItem(_dataInitializer.Milk, 1));
            basket.RemoveItem(_dataInitializer.CreateBasketItem(_dataInitializer.Milk, 1));
            basket.RemoveItem(_dataInitializer.CreateBasketItem(_dataInitializer.Milk, 1));

        }

        [TestMethod]
        public void TwoButters()
        {
            var basket = _dataInitializer.BasketFactory.GetBasket();
            basket.AddItem(_dataInitializer.CreateBasketItem(_dataInitializer.Butter, 2));
            var discounts = new List<IDiscount>() {  };

            var result = _dataInitializer.TotalCalculator.Calculate(basket, discounts);

            Assert.AreEqual(1.60m, result);
        }


    }
}

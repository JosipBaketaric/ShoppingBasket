using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasket.Common.Models;
using ShoppingBasket.Test.Data;
using System.Collections.Generic;

namespace ShoppingBasket.Test
{
    [TestClass]
    public class ScenariosTest
    {
        private readonly DataInitializer _dataInitializer;
        public ScenariosTest()
        {
            _dataInitializer = DataInitializer.GetInstance();
        }

        [TestMethod]
        public void OneBreadOneButterOneMilk()
        {
            var basket = _dataInitializer.BasketFactory.GetBasket();
            basket.AddItem(_dataInitializer.CreateBasketItem(_dataInitializer.Bread, 1));
            basket.AddItem(_dataInitializer.CreateBasketItem(_dataInitializer.Butter, 1));
            basket.AddItem(_dataInitializer.CreateBasketItem(_dataInitializer.Milk, 1));

            var discounts = new List<IDiscount>() { _dataInitializer.NItemDiscount, _dataInitializer.NItemOtherItemDiscount };

            var result = _dataInitializer.TotalCalculator.Calculate(basket, discounts);

            Assert.AreEqual(2.95m, result);
        }

        [TestMethod]
        public void TwoButtersTwoBreads()
        {
            var basket = _dataInitializer.BasketFactory.GetBasket();
            basket.AddItem(_dataInitializer.CreateBasketItem(_dataInitializer.Bread, 2));
            basket.AddItem(_dataInitializer.CreateBasketItem(_dataInitializer.Butter, 2));

            var discounts = new List<IDiscount>() { _dataInitializer.NItemDiscount, _dataInitializer.NItemOtherItemDiscount };

            var result = _dataInitializer.TotalCalculator.Calculate(basket, discounts);

            Assert.AreEqual(3.10m, result);
        }

        [TestMethod]
        public void FourMilks()
        {
            var basket = _dataInitializer.BasketFactory.GetBasket();
            basket.AddItem(_dataInitializer.CreateBasketItem(_dataInitializer.Milk, 4));

            var discounts = new List<IDiscount>() { _dataInitializer.NItemDiscount, _dataInitializer.NItemOtherItemDiscount };

            var result = _dataInitializer.TotalCalculator.Calculate(basket, discounts);

            Assert.AreEqual(3.45m, result);
        }

        [TestMethod]
        public void TwoButtersOneBreadEightMilks()
        {
            var basket = _dataInitializer.BasketFactory.GetBasket();
            basket.AddItem(_dataInitializer.CreateBasketItem(_dataInitializer.Milk, 8));
            basket.AddItem(_dataInitializer.CreateBasketItem(_dataInitializer.Butter, 2));
            basket.AddItem(_dataInitializer.CreateBasketItem(_dataInitializer.Bread, 1));


            var discounts = new List<IDiscount>() { _dataInitializer.NItemDiscount, _dataInitializer.NItemOtherItemDiscount };

            var result = _dataInitializer.TotalCalculator.Calculate(basket, discounts);

            Assert.AreEqual(9.00m, result);
        }
    }
}

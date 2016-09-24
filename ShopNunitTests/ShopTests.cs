using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shop;

namespace Shop.ShopNunitTests
{
    class ShopTests
    {
        private Shop _testShop;
        private Milk _testMilk;

        [SetUp]
        public void Init()
        {
            _testShop = new Shop("Food Store", "101st Corner Street", "George Warren");
            _testMilk = new Milk(101L, Milk.LITER, "Plain Milk inc.", DateTime.Now.AddDays(1), Milk.WHOLE_MILK);
        }

        [TearDown]
        public void Dispose()
        {
            _testShop = null;
            _testMilk = null;
        }

        [Test]
        public void GetNameTest()
        {
            Assert.AreEqual("Food Store", _testShop.Name);
        }

        [Test]
        public void GetAddressTest()
        {
            Assert.AreEqual("101st Corner Street", _testShop.Address);
        }

        [Test]
        public void OwnerTest()
        {
            Assert.AreEqual("George Warren", _testShop.Owner);
        }

        [Test]
        public void IsThereAnyMilkIfNotTest()
        {
            Assert.IsFalse(_testShop.IsThereAnyMilk());
        }

        [Test]
        public void IsThereAnyMilkIfYesTest()
        {
            _testShop.ReplenishFoodCounter(_testMilk);
            Assert.IsTrue(_testShop.IsThereAnyMilk());
        }

        [Test]
        public void ReplenishMilkCounterTest()
        {
            _testShop.ReplenishFoodCounter(_testMilk);
            Assert.IsTrue(_testShop.IsThereAnyMilk());
        }

        [Test]
        public void BuyMilkTest()
        {
            _testShop.ReplenishFoodCounter(_testMilk);
            Assert.AreEqual(_testMilk, _testShop.BuyFood(101L));
        }
    }
}

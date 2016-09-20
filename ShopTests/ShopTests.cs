using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Tests
{
    [TestClass()]
    public class ShopTests
    {
        private Shop _testShop;
        private Milk _testMilk;

        [TestInitialize]
        public void SetUp()
        {
            _testShop = new Shop("Food Store", "101st Corner Street", "George Warren");
            _testMilk = new Milk(101L, Milk.LITER, "Plain Milk inc.", DateTime.Now.AddDays(1), 2.8);
        }

        [TestCleanup]
        public void TearDown()
        {
            _testShop = null;
            _testMilk = null;
        }

        [TestMethod()]
        public void GetNameTest()
        {
            Assert.AreEqual("Food Store", _testShop.Name);
        }

        [TestMethod()]
        public void GetAddressTest()
        {
            Assert.AreEqual("101st Corner Street", _testShop.Address);
        }

        [TestMethod()]
        public void OwnerTest()
        {
            Assert.AreEqual("George Warren", _testShop.Owner);
        }

        [TestMethod()]
        public void IsThereAnyMilkIfNotTest()
        {
            Assert.IsFalse(_testShop.IsThereAnyMilk());
        }

        [TestMethod()]
        public void IsThereAnyMilkIfYesTest()
        {
            _testShop.FillUpMilkCounter(_testMilk);
            Assert.IsTrue(_testShop.IsThereAnyMilk());
        }

        [TestMethod()]
        public void FillUpMilkCounterTest()
        {
            _testShop.FillUpMilkCounter(_testMilk);
            Assert.IsTrue(_testShop.IsThereAnyMilk());  
        }

        [TestMethod()]
        public void BuyMilkTest()
        {
            _testShop.FillUpMilkCounter(_testMilk);
            Assert.AreEqual(_testMilk, _testShop.BuyMilk(101L));
        }
    }
}
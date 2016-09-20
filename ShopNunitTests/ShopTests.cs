﻿using System;
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
        public void SetUp()
        {
            _testShop = new Shop("Food Store", "101st Corner Street", "George Warren");
            _testMilk = new Milk(101L, Milk.LITER, "Plain Milk inc.", DateTime.Now.AddDays(1), 2.8);
        }

        [TearDown]
        public void TearDown()
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
            _testShop.FillUpMilkCounter(_testMilk);
            Assert.IsTrue(_testShop.IsThereAnyMilk());
        }

        [Test]
        public void FillUpMilkCounterTest()
        {
            _testShop.FillUpMilkCounter(_testMilk);
            Assert.IsTrue(_testShop.IsThereAnyMilk());
        }

        [Test]
        public void BuyMilkTest()
        {
            _testShop.FillUpMilkCounter(_testMilk);
            Assert.AreEqual(_testMilk, _testShop.BuyMilk(101L));
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shop;

namespace ShopNunitTests
{
    [TestFixture]
    public class MilkTests
    {
        Milk testMilk;
        DateTime testDate = DateTime.Now.AddDays(1);

        [SetUp]
        public void Init()
        {
            testMilk = new Milk(Milk.LITER, "Plain Milk inc.", testDate, 2.8, 210);
        }

        [TearDown]
        public void Dispose()
        {
            testMilk = null;
        }

        [Test]
        public void GetCubicCapacityTest()
        {
            Assert.AreEqual(1000, testMilk.CubicCapacity);
        }

        [Test]
        public void GetProducerTest()
        {
            Assert.AreEqual("Plain Milk inc.", testMilk.Producer);
        }

        [Test]
        public void GetBestBeforeTest()
        {
            Assert.AreEqual(testDate, testMilk.BestBefore);
        }

        [Test]
        public void GetFatContentTest()
        {
            Assert.AreEqual(2.8, testMilk.FatContent);
        }

        [Test]
        public void GetPriceTest()
        {
            Assert.AreEqual(210, testMilk.Price);
        }

        [Test]
        public void checkStillUnderGuaranteeTest()
        {
            Assert.AreEqual(true, testMilk.CheckStillUnderGuarantee());
        }

        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual("Milk{cubic capacity: 1000 ml, producer: 'Plain Milk inc.', best before: " + testDate +
                ", fat content: 2,8, price: 210 forint(s)}", testMilk.ToString());
        }
    }
}

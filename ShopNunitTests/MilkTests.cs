using System;
using NUnit.Framework;
using Shop;
using MockObjects;

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
            testMilk = new MilkMock(101L, Milk.LITER, "Plain Milk inc.", testDate, Milk.WHOLE_MILK);
        }

        [TearDown]
        public void Dispose()
        {
            testMilk = null;
        }

        [Test]
        public void GetBarcode()
        {
            Assert.AreEqual(101L, testMilk.Barcode);
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
        public void checkStillUnderGuaranteeTest()
        {
            Assert.True(testMilk.CheckStillUnderGuarantee());
        }

        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual("Milk{barcode: 101, cubic capacity: 1000 ml, producer: 'Plain Milk inc.', best before: " + testDate +
                ", fat content: 2,8%}", testMilk.ToString());
        }
    }
}

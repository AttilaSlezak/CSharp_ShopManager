using System;
using NUnit.Framework;
using Shop;
using MockObjects;

namespace ShopNunitTests
{
    [TestFixture]
    public class MilkTests
    {
        private Milk _testMilk;
        private DateTime _testDate = DateTime.Now.AddDays(1);

        [SetUp]
        public void Init()
        {
            _testMilk = new MilkMock(101L, Milk.LITER, "Plain Milk inc.", _testDate, Milk.WHOLE_MILK);
        }

        [TearDown]
        public void Dispose()
        {
            _testMilk = null;
        }

        [Test]
        public void GetBarcodeTest()
        {
            Assert.AreEqual(101L, _testMilk.Barcode);
        }

        [Test]
        public void GetCubicCapacityTest()
        {
            Assert.AreEqual(1000, _testMilk.CubicCapacity);
        }

        [Test]
        public void GetProducerTest()
        {
            Assert.AreEqual("Plain Milk inc.", _testMilk.Producer);
        }

        [Test]
        public void GetBestBeforeTest()
        {
            Assert.AreEqual(_testDate, _testMilk.BestBefore);
        }

        [Test]
        public void GetFatContentTest()
        {
            Assert.AreEqual(2.8, _testMilk.FatContent);
        }

        [Test]
        public void checkStillUnderGuaranteeTest()
        {
            Assert.True(_testMilk.CheckStillUnderGuarantee());
        }

        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual("Milk{barcode: 101, cubic capacity: 1000 ml, producer: 'Plain Milk inc.', best before: " + _testDate +
                ", fat content: 2,8%}", _testMilk.ToString());
        }
    }
}

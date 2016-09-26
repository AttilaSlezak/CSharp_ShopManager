using System;
using NUnit.Framework;
using Shop;
using MockObjects;

namespace ShopNunitTests
{
    [TestFixture]
    class FoodTests
    {
        private Food _testFood;
        private DateTime _testDate = DateTime.Today.AddDays(1);

        [SetUp]
        public void Init()
        {
            _testFood = new FoodMock(100L, "Food Producer inc.", _testDate);
        }

        [TearDown]
        public void Dispose()
        {
            _testFood = null;
        }

        [Test]
        public void GetBarcodeTest()
        {
            Assert.AreEqual(100L, _testFood.Barcode);
        }

        [Test]
        public void GetProducerTest()
        {
            Assert.AreEqual("Food Producer inc.", _testFood.Producer);
        }

        [Test]
        public void GetBestBeforeTest()
        {
            Assert.AreEqual(_testDate, _testFood.BestBefore);
        }

        [Test]
        public void CheckStillUnderGuaranteeTest()
        {
            Assert.IsTrue(_testFood.CheckStillUnderGuarantee());
        }

        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual("Food{barcode: " + _testFood.Barcode + ", producer: '" + _testFood.Producer + "', best before: " + _testFood.BestBefore + "}",
                _testFood.ToString());
        }
    }
}

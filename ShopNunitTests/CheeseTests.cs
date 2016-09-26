using System;
using NUnit.Framework;
using Shop;

namespace ShopNunitTests
{
    [TestFixture]
    class CheeseTests
    {
        private Cheese _testCheese;
        private DateTime _testDate = DateTime.Now.AddDays(1);

        [SetUp]
        public void Init()
        {
            _testCheese = new Cheese(120L, 700.0, "Normand Cheese inc.", _testDate, 40.0);
        }

        [TearDown]
        public void Dispose()
        {
            _testCheese = null;
        }

        [Test]
        public void GetBarcodeTest()
        {
            Assert.AreEqual(120L, _testCheese.Barcode);
        }

        [Test]
        public void GetCubicCapacityTest()
        {
            Assert.AreEqual(700.0, _testCheese.Weight);
        }

        [Test]
        public void GetProducerTest()
        {
            Assert.AreEqual("Normand Cheese inc.", _testCheese.Producer);
        }

        [Test]
        public void GetBestBeforeTest()
        {
            Assert.AreEqual(_testDate, _testCheese.BestBefore);
        }

        [Test]
        public void GetFatContentTest()
        {
            Assert.AreEqual(40.0, _testCheese.FatContent);
        }

        [Test]
        public void checkStillUnderGuaranteeTest()
        {
            Assert.True(_testCheese.CheckStillUnderGuarantee());
        }

        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual("Cheese{barcode: 120, weight: 700 g, producer: 'Normand Cheese inc.', best before: " + _testDate +
                ", fat content: 40%}", _testCheese.ToString());
        }
    }
}

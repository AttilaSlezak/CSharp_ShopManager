using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockObjects;
using System;


namespace Shop.Tests
{
    [TestClass()]
    public class FoodTests
    {
        private Food _testFood;
        private DateTime _testDate = DateTime.Today.AddDays(1);

        [TestInitialize]
        public void SetUp()
        {
            _testFood = new FoodMock(100L, "Food Producer inc.", _testDate);
        }

        [TestCleanup]
        public void TearDown()
        {
            _testFood = null;
        }

        [TestMethod()]
        public void GetBarcodeTest()
        {
            Assert.AreEqual(100L, _testFood.Barcode);
        }

        [TestMethod()]
        public void GetProducerTest()
        {
            Assert.AreEqual("Food Producer inc.", _testFood.Producer);
        }

        [TestMethod()]
        public void GetBestBeforeTest()
        {
            Assert.AreEqual(_testDate, _testFood.BestBefore);
        }

        [TestMethod()]
        public void CheckStillUnderGuaranteeTest()
        {
            Assert.IsTrue(_testFood.CheckStillUnderGuarantee());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("Food{barcode: " + _testFood.Barcode + ", producer: '" + _testFood.Producer + "', best before: " + _testFood.BestBefore + "}", 
                _testFood.ToString());
        }
    }
}
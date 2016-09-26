using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Shop.Tests
{
    [TestClass()]
    public class LongLifeMilkTests
    {
        private LongLifeMilk _testMilk;
        private DateTime _testDate = DateTime.Now.AddDays(1);

        [TestInitialize]
        public void SetUp()
        {
            _testMilk = new LongLifeMilk(101L, Milk.LITER, "Plain Milk inc.", _testDate, Milk.WHOLE_MILK);
        }

        [TestCleanup]
        public void TearDown()
        {
            _testMilk = null;
        }

        [TestMethod()]
        public void GetBarcodeTest()
        {
            Assert.AreEqual(101L, _testMilk.Barcode);
        }

        [TestMethod()]
        public void GetCubicCapacityTest()
        {
            Assert.AreEqual(1000, _testMilk.CubicCapacity);
        }

        [TestMethod()]
        public void GetProducerTest()
        {
            Assert.AreEqual("Plain Milk inc.", _testMilk.Producer);
        }

        [TestMethod()]
        public void GetBestBeforeTest()
        {
            Assert.AreEqual(_testDate, _testMilk.BestBefore);
        }

        [TestMethod()]
        public void GetFatContentTest()
        {
            Assert.AreEqual(2.8, _testMilk.FatContent);
        }

        [TestMethod()]
        public void checkStillUnderGuaranteeTest()
        {
            Assert.IsTrue(_testMilk.CheckStillUnderGuarantee());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("Milk{barcode: 101, cubic capacity: 1000 ml, producer: 'Plain Milk inc.', best before: " + _testDate +
                ", fat content: 2,8%}", _testMilk.ToString());
        }
    }
}
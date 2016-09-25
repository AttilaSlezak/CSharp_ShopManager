using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockObjects;
using System;


namespace Shop.Tests
{
    [TestClass()]
    public class MilkTests
    {
        Milk testMilk;
        DateTime testDate = DateTime.Now.AddDays(1);

        [TestInitialize]
        public void SetUp()
        {
            testMilk = new MilkMock(101L, Milk.LITER, "Plain Milk inc.", testDate, Milk.WHOLE_MILK);
        }

        [TestCleanup]
        public void TearDown()
        {
            testMilk = null;
        }

        [TestMethod()]
        public void GetBarcodeTest()
        {
            Assert.AreEqual(101L, testMilk.Barcode);
        }

        [TestMethod()]
        public void GetCubicCapacityTest()
        {
            Assert.AreEqual(1000, testMilk.CubicCapacity);
        }

        [TestMethod()]
        public void GetProducerTest()
        {
            Assert.AreEqual("Plain Milk inc.", testMilk.Producer);
        }

        [TestMethod()]
        public void GetBestBeforeTest()
        {
            Assert.AreEqual(testDate, testMilk.BestBefore);
        }

        [TestMethod()]
        public void GetFatContentTest()
        {
            Assert.AreEqual(2.8, testMilk.FatContent);
        }

        [TestMethod()]
        public void checkStillUnderGuaranteeTest()
        {
            Assert.IsTrue(testMilk.CheckStillUnderGuarantee());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("Milk{barcode: 101, cubic capacity: 1000 ml, producer: 'Plain Milk inc.', best before: " + testDate + 
                ", fat content: 2,8%}", testMilk.ToString());
        }
    }
}
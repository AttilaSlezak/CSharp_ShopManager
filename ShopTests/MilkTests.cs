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
    public class MilkTests
    {
        Milk testMilk;
        DateTime testDate = DateTime.Now.AddDays(1);

        [TestInitialize]
        public void SetUp()
        {
            testMilk = new Milk(101L, Milk.LITER, "Plain Milk inc.", testDate, 2.8, 210);
        }

        [TestCleanup]
        public void TearDown()
        {
            testMilk = null;
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
        public void GetPriceTest()
        {
            Assert.AreEqual(210, testMilk.Price);
        }

        [TestMethod()]
        public void checkStillUnderGuaranteeTest()
        {
            Assert.AreEqual(true, testMilk.CheckStillUnderGuarantee());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("Milk{bar code: 101, cubic capacity: 1000 ml, producer: 'Plain Milk inc.', best before: " + testDate + 
                ", fat content: 2,8, price: 210 forint(s)}", testMilk.ToString());
        }
    }
}
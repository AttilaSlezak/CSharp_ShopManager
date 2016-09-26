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
    public class CheeseTests
    {
        private Cheese _testCheese;
        private DateTime _testDate = DateTime.Now.AddDays(1);

        [TestInitialize]
        public void SetUp()
        {
            _testCheese = new Cheese(120L, 700.0, "Normand Cheese inc.", _testDate, 40.0);
        }

        [TestCleanup]
        public void TearDown()
        {
            _testCheese = null;
        }

        [TestMethod()]
        public void GetBarcodeTest()
        {
            Assert.AreEqual(120L, _testCheese.Barcode);
        }

        [TestMethod()]
        public void GetCubicCapacityTest()
        {
            Assert.AreEqual(700.0, _testCheese.Weight);
        }

        [TestMethod()]
        public void GetProducerTest()
        {
            Assert.AreEqual("Normand Cheese inc.", _testCheese.Producer);
        }

        [TestMethod()]
        public void GetBestBeforeTest()
        {
            Assert.AreEqual(_testDate, _testCheese.BestBefore);
        }

        [TestMethod()]
        public void GetFatContentTest()
        {
            Assert.AreEqual(40.0, _testCheese.FatContent);
        }

        [TestMethod()]
        public void checkStillUnderGuaranteeTest()
        {
            Assert.IsTrue(_testCheese.CheckStillUnderGuarantee());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("Cheese{barcode: 120, weight: 700 g, producer: 'Normand Cheese inc.', best before: " + _testDate +
                ", fat content: 40%}", _testCheese.ToString());
        }
    }
}
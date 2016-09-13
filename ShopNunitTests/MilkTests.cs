using System;
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
        [Test]
        public void GetCubicCapacityTest()
        {
            Milk milkTest = new Milk(1000, "Plain Milk inc.", new DateTime(2017, 1, 1), 2.8, 210);
            Assert.AreEqual(1000, milkTest.CubicCapacity);
        }

        [Test]
        public void GetProducerTest()
        {
            Milk milkTest = new Milk(1000, "Plain Milk inc.", new DateTime(2017, 1, 1), 2.8, 210);
            Assert.AreEqual("Plain Milk inc.", milkTest.Producer);
        }

        [Test]
        public void GetBestBeforeTest()
        {
            Milk milkTest = new Milk(1000, "Plain Milk inc.", new DateTime(2017, 1, 1), 2.8, 210);
            Assert.AreEqual(new DateTime(2017, 1, 1), milkTest.BestBefore);
        }

        [Test]
        public void GetFatContentTest()
        {
            Milk milkTest = new Milk(1000, "Plain Milk inc.", new DateTime(2017, 1, 1), 2.8, 210);
            Assert.AreEqual(2.8, milkTest.FatContent);
        }

        [Test]
        public void GetPriceTest()
        {
            Milk milkTest = new Milk(1000, "Plain Milk inc.", new DateTime(2017, 1, 1), 2.8, 210);
            Assert.AreEqual(210, milkTest.Price);
        }
        [Test]
        public void checkStillUnderGuaranteeTest()
        {
            Milk milkTest = new Milk(1000, "Plain Milk inc.", DateTime.Now.AddDays(1), 2.8, 210);
            Assert.AreEqual(true, milkTest.CheckStillUnderGuarantee());
        }

        [Test]
        public void ToStringTest()
        {
            Milk milkTest = new Milk(1000, "Plain Milk inc.", new DateTime(2017, 1, 1), 2.8, 210);
            Assert.AreEqual("Milk{cubic capacity: 1000 ml, producer: 'Plain Milk inc.', best before: 2017.01.01. 0:00:00" +
                ", fat content: 2,8, price: 210 forint(s)}", milkTest.ToString());
        }

    }
}

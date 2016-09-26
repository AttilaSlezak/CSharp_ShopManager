using System;
using NUnit.Framework;
using Shop;

namespace ShopNunitTests
{
    [TestFixture]
    class MilkFactoryTests
    {
        [Test]
        public void NewLongLifeMilkTest()
        {
            Milk milk = MilkFactory.NewLongLifeMilk(101L, Milk.LITER, "Plain Milk inc.", DateTime.Now.AddDays(1), Milk.WHOLE_MILK);
            Assert.AreEqual(typeof(LongLifeMilk), milk.GetType());
        }

        [Test]
        public void NewSemiLongLifeMilkTest()
        {
            Milk milk = MilkFactory.NewSemiLongLifeMilk(101L, Milk.LITER, "Plain Milk inc.", DateTime.Now.AddDays(1), Milk.WHOLE_MILK);
            Assert.AreEqual(typeof(SemiLongLifeMilk), milk.GetType());
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Shop.Tests
{
    [TestClass()]
    public class MilkFactoryTests
    {
        [TestMethod()]
        public void NewLongLifeMilkTest()
        {
            Milk milk = MilkFactory.NewLongLifeMilk(101L, Milk.LITER, "Plain Milk inc.", DateTime.Now.AddDays(1), Milk.WHOLE_MILK);
            Assert.AreEqual(typeof(LongLifeMilk), milk.GetType());
        }

        [TestMethod()]
        public void NewSemiLongLifeMilkTest()
        {
            Milk milk = MilkFactory.NewSemiLongLifeMilk(101L, Milk.LITER, "Plain Milk inc.", DateTime.Now.AddDays(1), Milk.WHOLE_MILK);
            Assert.AreEqual(typeof(SemiLongLifeMilk), milk.GetType());
        }
    }
}
using Shop;
using System;
using Xunit;


namespace ShopXUnitTests
{
    public class MilkFactoryTests
    {
        [Fact]
        public void NewLongLifeMilkTest()
        {
            Milk milk = MilkFactory.NewLongLifeMilk(101L, Milk.LITER, "Plain Milk inc.", DateTime.Now.AddDays(1), Milk.WHOLE_MILK);
            Assert.Equal(typeof(LongLifeMilk), milk.GetType());
        }

        [Fact]
        public void NewSemiLongLifeMilkTest()
        {
            Milk milk = MilkFactory.NewSemiLongLifeMilk(101L, Milk.LITER, "Plain Milk inc.", DateTime.Now.AddDays(1), Milk.WHOLE_MILK);
            Assert.Equal(typeof(SemiLongLifeMilk), milk.GetType());
        }
    }
}

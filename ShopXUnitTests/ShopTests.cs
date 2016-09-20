using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shop;
using ShopClass = Shop.Shop;

namespace ShopXUnitTests
{
    public class ShopTests : IDisposable
    {
        private ShopClass _testShop;
        private Milk _testMilk;

        public ShopTests()
        {
            _testShop = new ShopClass("Food Store", "101st Corner Street", "George Warren");
            _testMilk = new Milk(101L, Milk.LITER, "Plain Milk inc.", DateTime.Now.AddDays(1), 2.8);
        }

        public void Dispose()
        {
            _testShop = null;
            _testMilk = null;
        }

        [Fact]
        public void GetNameTest()
        {
            Assert.Equal("Food Store", _testShop.Name);
        }

        [Fact]
        public void GetAddressTest()
        {
            Assert.Equal("101st Corner Street", _testShop.Address);
        }

        [Fact]
        public void OwnerTest()
        {
            Assert.Equal("George Warren", _testShop.Owner);
        }

        [Fact]
        public void IsThereAnyMilkIfNotTest()
        {
            Assert.False(_testShop.IsThereAnyMilk());
        }

        [Fact]
        public void IsThereAnyMilkIfYesTest()
        {
            _testShop.FillUpMilkCounter(_testMilk);
            Assert.True(_testShop.IsThereAnyMilk());
        }

        [Fact]
        public void FillUpMilkCounterTest()
        {
            _testShop.FillUpMilkCounter(_testMilk);
            Assert.True(_testShop.IsThereAnyMilk());
        }

        [Fact]
        public void BuyMilkTest()
        {
            _testShop.FillUpMilkCounter(_testMilk);
            Assert.Equal(_testMilk, _testShop.BuyMilk(101L));
        }
    }
}

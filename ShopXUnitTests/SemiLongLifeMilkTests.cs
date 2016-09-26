using Shop;
using System;
using Xunit;

namespace ShopXUnitTests
{
    public class SemiLongLifeMilkTests
    {
        private SemiLongLifeMilk _testMilk;
        private DateTime _testDate = DateTime.Now.AddDays(1);

        public SemiLongLifeMilkTests()
        {
            _testMilk = new SemiLongLifeMilk(101L, Milk.LITER, "Plain Milk inc.", _testDate, Milk.WHOLE_MILK);
        }

        public void Dispose()
        {
            _testMilk = null;
        }

        [Fact]
        public void GetBarcodeTest()
        {
            Assert.Equal(101L, _testMilk.Barcode);
        }

        [Fact]
        public void GetCubicCapacityTest()
        {
            Assert.Equal(1000, _testMilk.CubicCapacity);
        }

        [Fact]
        public void GetProducerTest()
        {
            Assert.Equal("Plain Milk inc.", _testMilk.Producer);
        }

        [Fact]
        public void GetBestBeforeTest()
        {
            Assert.Equal(_testDate, _testMilk.BestBefore);
        }

        [Fact]
        public void GetFatContentTest()
        {
            Assert.Equal(2.8, _testMilk.FatContent);
        }

        [Fact]
        public void checkStillUnderGuaranteeTest()
        {
            Assert.True(_testMilk.CheckStillUnderGuarantee());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal("Milk{barcode: 101, cubic capacity: 1000 ml, producer: 'Plain Milk inc.', best before: " + _testDate +
                ", fat content: 2,8%}", _testMilk.ToString());
        }
    }
}

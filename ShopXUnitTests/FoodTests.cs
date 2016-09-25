using MockObjects;
using Shop;
using System;
using Xunit;

namespace ShopXUnitTests
{
    public class FoodTests
    {
        private Food _testFood;
        private DateTime _testDate = DateTime.Today.AddDays(1);

        public FoodTests()
        {
            _testFood = new FoodMock(100L, "Food Producer inc.", _testDate);
        }

        public void Dispose()
        {
            _testFood = null;
        }

        [Fact]
        public void GetBarcodeTest()
        {
            Assert.Equal(100L, _testFood.Barcode);
        }

        [Fact]
        public void GetProducerTest()
        {
            Assert.Equal("Food Producer inc.", _testFood.Producer);
        }

        [Fact]
        public void GetBestBeforeTest()
        {
            Assert.Equal(_testDate, _testFood.BestBefore);
        }

        [Fact]
        public void CheckStillUnderGuaranteeTest()
        {
            Assert.True(_testFood.CheckStillUnderGuarantee());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal("Food{barcode: " + _testFood.Barcode + ", producer: '" + _testFood.Producer + "', best before: " + _testFood.BestBefore + "}",
                _testFood.ToString());
        }
    }
}

using System;
using Xunit;
using Shop;

namespace ShopXUnitTests
{
    public class CheeseTests
    {
        private Cheese _testCheese;
        private DateTime _testDate = DateTime.Now.AddDays(1);

        public CheeseTests()
        {
            _testCheese = new Cheese(120L, 700.0, "Normand Cheese inc.", _testDate, 40.0);
        }

        public void Dispose()
        {
            _testCheese = null;
        }

        [Fact]
        public void GetBarcodeTest()
        {
            Assert.Equal(120L, _testCheese.Barcode);
        }

        [Fact]
        public void GetCubicCapacityTest()
        {
            Assert.Equal(700.0, _testCheese.Weight);
        }

        [Fact]
        public void GetProducerTest()
        {
            Assert.Equal("Normand Cheese inc.", _testCheese.Producer);
        }

        [Fact]
        public void GetBestBeforeTest()
        {
            Assert.Equal(_testDate, _testCheese.BestBefore);
        }

        [Fact]
        public void GetFatContentTest()
        {
            Assert.Equal(40.0, _testCheese.FatContent);
        }

        [Fact]
        public void checkStillUnderGuaranteeTest()
        {
            Assert.True(_testCheese.CheckStillUnderGuarantee());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal("Cheese{barcode: 120, weight: 700 g, producer: 'Normand Cheese inc.', best before: " + _testDate +
                ", fat content: 40%}", _testCheese.ToString());
        }
    }
}

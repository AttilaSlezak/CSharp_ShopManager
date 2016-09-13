using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shop;

namespace ShopXUnitTests
{
    public class MilkTests
    {
        [Fact]
        public void GetCubicCapacityTest()
        {
            Milk milkTest = new Milk(1000, "Plain Milk inc.", new DateTime(2017, 1, 1), 2.8, 210);
            Assert.Equal(1000, milkTest.CubicCapacity);
        }

        [Fact]
        public void GetProducerTest()
        {
            Milk milkTest = new Milk(1000, "Plain Milk inc.", new DateTime(2017, 1, 1), 2.8, 210);
            Assert.Equal("Plain Milk inc.", milkTest.Producer);
        }

        [Fact]
        public void GetBestBeforeTest()
        {
            Milk milkTest = new Milk(1000, "Plain Milk inc.", new DateTime(2017, 1, 1), 2.8, 210);
            Assert.Equal(new DateTime(2017, 1, 1), milkTest.BestBefore);
        }

        [Fact]
        public void GetFatContentTest()
        {
            Milk milkTest = new Milk(1000, "Plain Milk inc.", new DateTime(2017, 1, 1), 2.8, 210);
            Assert.Equal(2.8, milkTest.FatContent);
        }

        [Fact]
        public void GetPriceTest()
        {
            Milk milkTest = new Milk(1000, "Plain Milk inc.", new DateTime(2017, 1, 1), 2.8, 210);
            Assert.Equal(210, milkTest.Price);
        }

        [Fact]
        public void checkStillUnderGuaranteeTest()
        {
            Milk milkTest = new Milk(1000, "Plain Milk inc.", DateTime.Now.AddDays(1), 2.8, 210);
            Assert.Equal(true, milkTest.CheckStillUnderGuarantee());
        }

        [Fact]
        public void ToStringTest()
        {
            Milk milkTest = new Milk(1000, "Plain Milk inc.", new DateTime(2017, 1, 1), 2.8, 210);
            Assert.Equal("Milk{cubic capacity: 1000 ml, producer: 'Plain Milk inc.', best before: 2017.01.01. 0:00:00" +
                ", fat content: 2,8, price: 210 forint(s)}", milkTest.ToString());
        }
    }
}

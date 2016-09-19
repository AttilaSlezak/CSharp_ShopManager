﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shop;

namespace ShopXUnitTests
{
    public class MilkTests : IDisposable
    {
        Milk testMilk;
        DateTime testDate = DateTime.Now.AddDays(1);

        public MilkTests()
        {
            testMilk = new Milk(101L, Milk.LITER, "Plain Milk inc.", testDate, 2.8);
        }

        [Fact]
        public void GetCubicCapacityTest()
        {
            Assert.Equal(1000, testMilk.CubicCapacity);
        }

        [Fact]
        public void GetProducerTest()
        {
            Assert.Equal("Plain Milk inc.", testMilk.Producer);
        }

        [Fact]
        public void GetBestBeforeTest()
        {
            Assert.Equal(testDate, testMilk.BestBefore);
        }

        [Fact]
        public void GetFatContentTest()
        {
            Assert.Equal(2.8, testMilk.FatContent);
        }

        [Fact]
        public void checkStillUnderGuaranteeTest()
        {
            Assert.Equal(true, testMilk.CheckStillUnderGuarantee());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal("Milk{cubic capacity: 1000 ml, producer: 'Plain Milk inc.', best before: " + testDate +
                ", fat content: 2,8}", testMilk.ToString());
        }

        public void Dispose()
        {
            testMilk = null;
        }
    }
}

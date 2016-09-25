using System;
using Xunit;
using static AuxiliaryClassesForTesting.PrivateDataAccessor;

namespace ShopXUnitTests
{
    public class PrivateDataAccessorTests
    {
        private String _testString;
        private int[] _testIntArray;

        public PrivateDataAccessorTests()
        {
            _testString = "Test text.";
            _testIntArray = new int[4] { 1, 2, 6, 4 };
        }

        public void Dispose()
        {
            _testString = null;
            _testIntArray = null;
        }

        [Fact]
        public void GetObjectFromCertainMethodTest()
        {
            Type type = (Type)GetObjectFromCertainMethod("GetType", typeof(string).GetMethods(), _testString);
            Assert.Equal(typeof(string), type);
        }

        [Fact]
        public void GetObjectFromCertainMethodWithParameterTest()
        {
            int index = (int)GetObjectFromCertainMethod("IndexOf", typeof(string).GetMethods(), _testString, 's');
            Assert.Equal(2, index);
        }

        [Fact]
        public void SetObjectInCertainMethodTest()
        {
            object[] args = { 3, 2 };
            SetObjectInCertainMethod("SetValue", typeof(int[]).GetMethods(), _testIntArray, args);
            Assert.Equal(3, _testIntArray[2]);
        }
    }
}

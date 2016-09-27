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
        public void GetObjectFromCertainPropertyTest()
        {
            int length = (int)GetObjectFromCertainProperty(typeof(string).GetProperty("Length"), _testString);
            Assert.Equal(_testString.Length, length);
        }

        [Fact]
        public void GetObjectFromCertainMethodTest()
        {
            Type type = (Type)GetObjectFromCertainMethod(typeof(string).GetMethod("GetType"), _testString);
            Assert.Equal(typeof(string), type);
        }

        [Fact]
        public void GetObjectFromCertainMethodWithSearchForMethodTest()
        {
            Type type = (Type)GetObjectFromCertainMethod("GetType", typeof(string).GetMethods(), _testString);
            Assert.Equal(typeof(string), type);
        }

        [Fact]
        public void GetObjectFromCertainMethodWithSearchForParameterTest()
        {
            int index = (int)GetObjectFromCertainMethod("IndexOf", typeof(string).GetMethods(), _testString, 's');
            Assert.Equal(2, index);
        }

        [Fact]
        public void GetObjectFromCertainMethodWithParameterTest()
        {
            Type[] searchedTypes = { typeof(char) };
            int index = (int)GetObjectFromCertainMethod(typeof(string).GetMethod("IndexOf", searchedTypes), _testString, 's');
            Assert.Equal(2, index);
        }

        [Fact]
        public void SetObjectInCertainMethodWithSearchForMethodTest()
        {
            object[] args = { 3, 2 };
            SetObjectInCertainMethod("SetValue", typeof(int[]).GetMethods(), _testIntArray, args);
            Assert.Equal(3, _testIntArray[2]);
        }

        [Fact]
        public void SetObjectInCertainMethodTest()
        {
            object[] args = { 3, 2 };
            Type[] searchedTypes = { typeof(int), typeof(int) };
            SetObjectInCertainMethod(typeof(int[]).GetMethod("SetValue", searchedTypes), _testIntArray, args);
            Assert.Equal(3, _testIntArray[2]);
        }
    }
}

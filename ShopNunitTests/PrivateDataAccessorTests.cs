using System;
using NUnit.Framework;
using static AuxiliaryClassesForTesting.PrivateDataAccessor;

namespace ShopNunitTests
{
    [TestFixture]
    class PrivateDataAccessorTests
    {
        private String _testString;
        private int[] _testIntArray;

        [SetUp]
        public void Init()
        {
            _testString = "Test text.";
            _testIntArray = new int[4] { 1, 2, 6, 4};
        }

        [TearDown]
        public void Dispose()
        {
            _testString = null;
            _testIntArray = null;
        }

        [Test]
        public void GetObjectFromCertainMethodTest()
        {           
            Type type = (Type)GetObjectFromCertainMethod("GetType", typeof(string).GetMethods(), _testString);
            Assert.AreEqual(typeof(string), type);
        }

        [Test]
        public void GetObjectFromCertainMethodWithParameterTest()
        {
            int index = (int)GetObjectFromCertainMethod("IndexOf", typeof(string).GetMethods(), _testString, 's');
            Assert.AreEqual(2, index);
        }

        [Test]
        public void SetObjectInCertainMethodTest()
        {
            object[] args = { 3, 2 };
            SetObjectInCertainMethod("SetValue", typeof(int[]).GetMethods(), _testIntArray, args);
            Assert.AreEqual(3, _testIntArray[2]);
        }
    }
}

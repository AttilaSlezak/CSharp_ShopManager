using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static AuxiliaryClassesForTesting.PrivateDataAccessor;

namespace Shop.Tests
{
    [TestClass()]
    public class PrivateDataAccessorTests
    {
        private String _testString;
        private int[] _testIntArray;

        [TestInitialize]
        public void SetUp()
        {
            _testString = "Test text.";
            _testIntArray = new int[4] { 1, 2, 6, 4 };
        }

        [TestCleanup]
        public void TearDown()
        {
            _testString = null;
            _testIntArray = null;
        }

        [TestMethod]
        public void GetObjectFromCertainMethodTest()
        {
            Type type = (Type)GetObjectFromCertainMethod("GetType", typeof(string).GetMethods(), _testString);
            Assert.AreEqual(typeof(string), type);
        }

        [TestMethod]
        public void GetObjectFromCertainMethodWithParameterTest()
        {
            int index = (int)GetObjectFromCertainMethod("IndexOf", typeof(string).GetMethods(), _testString, 's');
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void SetObjectInCertainMethodTest()
        {
            object[] args = { 3, 2 };
            SetObjectInCertainMethod("SetValue", typeof(int[]).GetMethods(), _testIntArray, args);
            Assert.AreEqual(3, _testIntArray[2]);
        }
    }
}

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
        public void GetObjectFromCertainPropertyTest()
        {
            int length = (int)GetObjectFromCertainProperty(typeof(string).GetProperty("Length"), _testString);
            Assert.AreEqual(_testString.Length, length);
        }

        [TestMethod]
        public void GetObjectFromCertainMethodTest()
        {
            Type type = (Type)GetObjectFromCertainMethod(typeof(string).GetMethod("GetType"), _testString);
            Assert.AreEqual(typeof(string), type);
        }

        [TestMethod]
        public void GetObjectFromCertainMethodWithSearchForMethodTest()
        {
            Type type = (Type)GetObjectFromCertainMethod("GetType", typeof(string).GetMethods(), _testString);
            Assert.AreEqual(typeof(string), type);
        }

        [TestMethod]
        public void GetObjectFromCertainMethodWithSearchForParameterTest()
        {
            int index = (int)GetObjectFromCertainMethod("IndexOf", typeof(string).GetMethods(), _testString, 's');
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void GetObjectFromCertainMethodWithParameterTest()
        {
            Type[] searchedTypes = { typeof(char) };
            int index = (int)GetObjectFromCertainMethod(typeof(string).GetMethod("IndexOf", searchedTypes), _testString, 's');
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void SetObjectInCertainMethodWithSearchForMethodTest()
        {
            object[] args = { 3, 2 };
            SetObjectInCertainMethod("SetValue", typeof(int[]).GetMethods(), _testIntArray, args);
            Assert.AreEqual(3, _testIntArray[2]);
        }

        [TestMethod]
        public void SetObjectInCertainMethodTest()
        {
            object[] args = { 3, 2 };
            Type[] searchedTypes = { typeof(int), typeof(int) };
            SetObjectInCertainMethod(typeof(int[]).GetMethod("SetValue", searchedTypes), _testIntArray, args);
            Assert.AreEqual(3, _testIntArray[2]);
        }
    }
}

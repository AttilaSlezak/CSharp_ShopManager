using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Reflection;
using static AuxiliaryClassesForTesting.PrivateDataAccessor;

namespace Shop.Tests
{
    [TestClass()]
    public class ShopTests
    {
        private MethodInfo[] _methodsShopPrivate = typeof(Shop).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        private MethodInfo[] _methodsShopReg = typeof(Shop).GetNestedTypes(BindingFlags.NonPublic)[0].GetMethods();
        private Hashtable _testShopFoodCounter;
        private Shop _testShop;
        private Milk _testMilk;
        private Cheese _testCheese;

        [TestInitialize]
        public void SetUp()
        {
            _testShop = new Shop("Food Store", "101st Corner Street", "George Warren");
            _testMilk = MilkFactory.NewLongLifeMilk(101L, Milk.LITER, "Plain Milk inc.", DateTime.Now.AddDays(1), Milk.WHOLE_MILK);
            _testCheese = new Cheese(120L, 700, "Normand Cheese inc.", DateTime.Now.AddDays(1), 40.0);
            FieldInfo fieldFoodCounter = typeof(Shop).GetField("_foodCounter", BindingFlags.Instance | BindingFlags.NonPublic);
            _testShopFoodCounter = (Hashtable)fieldFoodCounter.GetValue(_testShop);
        }

        [TestCleanup]
        public void TearDown()
        {
            _testShop = null;
            _testMilk = null;
            _testCheese = null;
            _testShopFoodCounter = null;
        }

        [TestMethod]
        public void GetNameTest()
        {
            Assert.AreEqual("Food Store", _testShop.Name);
        }

        [TestMethod]
        public void GetAddressTest()
        {
            Assert.AreEqual("101st Corner Street", _testShop.Address);
        }

        [TestMethod]
        public void OwnerTest()
        {
            Assert.AreEqual("George Warren", _testShop.Owner);
        }

        [TestMethod]
        public void IsThereAnyMilkIfNotTest()
        {
            Assert.IsFalse(_testShop.IsThereAnyMilk());
        }

        [TestMethod]
        public void IsThereAnyMilkIfYesTest()
        {
            _testShop.AddNewFoodToFoodCounter(_testMilk, 1L, 100);
            Assert.IsTrue(_testShop.IsThereAnyMilk());
        }

        [TestMethod]
        public void IsThereAnyCheeseIfNotTest()
        {
            Assert.IsFalse(_testShop.IsThereAnyCheese());
        }

        [TestMethod]
        public void IsThereAnyCheeseIfYesTest()
        {
            _testShop.AddNewFoodToFoodCounter(_testCheese, 1L, 100);
            Assert.IsTrue(_testShop.IsThereAnyCheese());
        }

        [TestMethod]
        public void IsThereAnyCertainFoodIfNot()
        {
            _testShop.AddNewFoodToFoodCounter(_testMilk, 3L, 100L);
            bool result = (bool)GetObjectFromCertainMethod("IsThereAnyCertainFood", _methodsShopPrivate, _testShop, typeof(Cheese));
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsThereAnyCertainFoodIfYes()
        {
            _testShop.AddNewFoodToFoodCounter(_testCheese, 5L, 200L);
            bool result = (bool)GetObjectFromCertainMethod("IsThereAnyCertainFood", _methodsShopPrivate, _testShop, typeof(Cheese));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddNewFoodToFoodCounterTest()
        {
            _testShop.AddNewFoodToFoodCounter(_testMilk, 3L, 100L);
            Assert.AreEqual(3L, GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _testShopFoodCounter[_testMilk.Barcode]));
        }

        [TestMethod]
        public void ReplenishFoodCounterTest()
        {
            _testShop.AddNewFoodToFoodCounter(_testMilk, 3L, 100L);
            _testShop.ReplenishFoodCounter(_testMilk.Barcode, 2L);
            Assert.AreEqual(5L, GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _testShopFoodCounter[_testMilk.Barcode]));
        }

        [TestMethod]
        public void RemoveFoodFromFoodCounterTest()
        {
            _testShop.AddNewFoodToFoodCounter(_testMilk, 3L, 100L);
            _testShop.RemoveFoodFromFoodCounter(_testMilk.Barcode);
            Assert.IsFalse(_testShopFoodCounter.ContainsKey(_testMilk.Barcode));
        }

        [TestMethod]
        public void BuyMilkTest()
        {
            _testShop.AddNewFoodToFoodCounter(_testMilk, 3L, 100L);
            _testShop.BuyFood(_testMilk.Barcode, 2L);
            Assert.AreEqual(1L, GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _testShopFoodCounter[_testMilk.Barcode]));
        }
    }
}
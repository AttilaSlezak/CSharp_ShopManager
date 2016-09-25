using System;
using NUnit.Framework;
using System.Reflection;
using System.Collections;
using static AuxiliaryClassesForTesting.PrivateDataAccessor;

namespace Shop.ShopNunitTests
{
    class ShopTests
    {
        private MethodInfo[] _methodsShopPrivate = typeof(Shop).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        private MethodInfo[] _methodsShopReg = typeof(Shop).GetNestedTypes(BindingFlags.NonPublic)[0].GetMethods();
        private Hashtable _testShopFoodCounter;
        private Shop _testShop;
        private Milk _testMilk;
        private Cheese _testCheese;

        [SetUp]
        public void Init()
        {
            _testShop = new Shop("Food Store", "101st Corner Street", "George Warren");
            _testMilk = MilkFactory.NewLongLifeMilk(101L, Milk.LITER, "Plain Milk inc.", DateTime.Now.AddDays(1), Milk.WHOLE_MILK);
            _testCheese = new Cheese(120L, 700, "Normand Cheese inc.", DateTime.Now.AddDays(1), 40.0);
            FieldInfo fieldFoodCounter = typeof(Shop).GetField("_foodCounter", BindingFlags.Instance | BindingFlags.NonPublic);
            _testShopFoodCounter = (Hashtable)fieldFoodCounter.GetValue(_testShop);
        }

        [TearDown]
        public void Dispose()
        {
            _testShop = null;
            _testMilk = null;
            _testCheese = null;
            _testShopFoodCounter = null;
        }

        [Test]
        public void GetNameTest()
        {
            Assert.AreEqual("Food Store", _testShop.Name);
        }

        [Test]
        public void GetAddressTest()
        {
            Assert.AreEqual("101st Corner Street", _testShop.Address);
        }

        [Test]
        public void OwnerTest()
        {
            Assert.AreEqual("George Warren", _testShop.Owner);
        }

        [Test]
        public void IsThereAnyMilkIfNotTest()
        {
            Assert.False(_testShop.IsThereAnyMilk());
        }

        [Test]
        public void IsThereAnyMilkIfYesTest()
        {
            _testShop.AddNewFoodToFoodCounter(_testMilk, 1L, 100);
            Assert.True(_testShop.IsThereAnyMilk());
        }

        [Test]
        public void IsThereAnyCheeseIfNotTest()
        {
            Assert.False(_testShop.IsThereAnyCheese());
        }

        [Test]
        public void IsThereAnyCheeseIfYesTest()
        {
            _testShop.AddNewFoodToFoodCounter(_testCheese, 1L, 100);
            Assert.True(_testShop.IsThereAnyCheese());
        }

        [Test]
        public void IsThereAnyCertainFoodIfNot()
        {
            _testShop.AddNewFoodToFoodCounter(_testMilk, 3L, 100L);
            bool result = (bool)GetObjectFromCertainMethod("IsThereAnyCertainFood", _methodsShopPrivate, _testShop, typeof(Cheese));
            Assert.False(result);
        }

        [Test]
        public void IsThereAnyCertainFoodIfYes()
        {
            _testShop.AddNewFoodToFoodCounter(_testCheese, 5L, 200L);
            bool result = (bool)GetObjectFromCertainMethod("IsThereAnyCertainFood", _methodsShopPrivate, _testShop, typeof(Cheese));
            Assert.True(result);
        }

        [Test]
        public void AddNewFoodToFoodCounterTest()
        {
            _testShop.AddNewFoodToFoodCounter(_testMilk, 3L, 100L);
            Assert.AreEqual(3L, GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _testShopFoodCounter[_testMilk.Barcode]));
        }

        [Test]
        public void ReplenishFoodCounterTest()
        {
            _testShop.AddNewFoodToFoodCounter(_testMilk, 3L, 100L);
            _testShop.ReplenishFoodCounter(_testMilk.Barcode, 2L);
            Assert.AreEqual(5L, GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _testShopFoodCounter[_testMilk.Barcode]));
        }

        [Test]
        public void RemoveFoodFromFoodCounterTest()
        {
            _testShop.AddNewFoodToFoodCounter(_testMilk, 3L, 100L);
            _testShop.RemoveFoodFromFoodCounter(_testMilk.Barcode);
            Assert.False(_testShopFoodCounter.ContainsKey(_testMilk.Barcode));
        }

        [Test]
        public void BuyMilkTest()
        {
            _testShop.AddNewFoodToFoodCounter(_testMilk, 3L, 100L);
            _testShop.BuyFood(_testMilk.Barcode, 2L);
            Assert.AreEqual(1L, GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _testShopFoodCounter[_testMilk.Barcode]));
        }
    }
}

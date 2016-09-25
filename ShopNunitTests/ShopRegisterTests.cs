using System;
using System.Reflection;
using NUnit.Framework;
using Shop;
using static AuxiliaryClassesForTesting.PrivateDataAccessor;

namespace ShopNunitTests
{
    class ShopRegisterTests
    {
        private MethodInfo[] _methodsShopReg = typeof(Shop.Shop).GetNestedTypes(BindingFlags.NonPublic)[0].GetMethods();
        private Milk _testMilk;
        private Object _objShopReg;

        [SetUp]
        public void Init()
        {
            _testMilk = MilkFactory.NewLongLifeMilk(101L, Milk.LITER, "Plain Milk inc.", DateTime.Now.AddDays(1), Milk.WHOLE_MILK);

            Type typeShop = typeof(Shop.Shop);
            Type[] typeShopReg = typeShop.GetNestedTypes(BindingFlags.NonPublic);
            ConstructorInfo constShopReg = typeShopReg[0].GetConstructors()[0];
            _objShopReg = constShopReg.Invoke(new object[] { _testMilk, 3, 100 });
        }

        [TearDown]
        public void Dispose()
        {
            _testMilk = null;
            _objShopReg = null;
        }

        [Test]
        public void GetFoodTest()
        {
            Milk milk = (Milk)GetObjectFromCertainMethod("get_Food", _methodsShopReg, _objShopReg);
            Assert.AreEqual(_testMilk, milk);
        }

        [Test]
        public void SetFoodTest()
        {
            Milk milk = MilkFactory.NewSemiLongLifeMilk(201L, Milk.HALF_LITER, "Plain Milk inc.", new DateTime(), Milk.LOW_FAT_MILK);
            SetObjectInCertainMethod("set_Food", _methodsShopReg, _objShopReg, milk);
            Milk resultMilk = (Milk)GetObjectFromCertainMethod("get_Food", _methodsShopReg, _objShopReg);
            Assert.AreEqual(resultMilk, milk);
        }

        [Test]
        public void GetQuantityTest()
        {
            long quantity = (long)GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _objShopReg);
            Assert.AreEqual(3L, quantity);
        }

        [Test]
        public void SetQuantityTest()
        {
            SetObjectInCertainMethod("set_Quantity", _methodsShopReg, _objShopReg, 10L);
            long resultQuantity = (long)GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _objShopReg);
            Assert.AreEqual(10L, resultQuantity);
        }

        [Test]
        public void AddQuantityTest()
        {
            long quantity = (long)GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _objShopReg);
            long difference = 5L;
            SetObjectInCertainMethod("AddQuantity", _methodsShopReg, _objShopReg, difference);
            long resultQuantity = (long)GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _objShopReg);
            Assert.AreEqual(quantity + difference, resultQuantity);
        }

        [Test]
        public void SubtractQuantityTest()
        {
            long quantity = (long)GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _objShopReg);
            long difference = 5L;
            SetObjectInCertainMethod("SubtractQuantity", _methodsShopReg, _objShopReg, difference);
            long resultQuantity = (long)GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _objShopReg);
            Assert.AreEqual(quantity - difference, resultQuantity);
        }

        [Test]
        public void GetPriceTest()
        {
            long resultPrice = (long)GetObjectFromCertainMethod("get_Price", _methodsShopReg, _objShopReg);
            Assert.AreEqual(100L, resultPrice);
        }

        [Test]
        public void SetPriceTest()
        {
            SetObjectInCertainMethod("set_Price", _methodsShopReg, _objShopReg, 200L);
            long resultPrice = (long)GetObjectFromCertainMethod("get_Price", _methodsShopReg, _objShopReg);
            Assert.AreEqual(200L, resultPrice);
        }
    }
}

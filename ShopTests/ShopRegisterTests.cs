using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AuxiliaryClassesForTesting.PrivateDataAccessor;

namespace Shop.ShopRegistrationTests
{
    [TestClass]
    public class ShopRegisterTests
    {
        private MethodInfo[] _methodsShopReg = typeof(Shop).GetNestedTypes(BindingFlags.NonPublic)[0].GetMethods();
        private Milk _testMilk;
        private Object _objShopReg;

        [TestInitialize]
        public void SetUp()
        {
            _testMilk = MilkFactory.NewLongLifeMilk(101L, Milk.LITER, "Plain Milk inc.", DateTime.Now.AddDays(1), Milk.WHOLE_MILK);

            Type typeShop = typeof(Shop);
            Type[] typeShopReg = typeShop.GetNestedTypes(BindingFlags.NonPublic);
            ConstructorInfo constShopReg = typeShopReg[0].GetConstructors()[0];
            _objShopReg = constShopReg.Invoke(new object[] { _testMilk, 3, 100 });
        }

        [TestCleanup]
        public void TearDown()
        {
            _testMilk = null;
            _objShopReg = null;
        }

        [TestMethod]
        public void GetFoodTest()
        {
            Milk milk = (Milk)GetObjectFromCertainMethod("get_Food", _methodsShopReg, _objShopReg);
            Assert.AreEqual(_testMilk, milk);
        }

        [TestMethod]
        public void SetFoodTest()
        {
            Milk milk = MilkFactory.NewSemiLongLifeMilk(201L, Milk.HALF_LITER, "Plain Milk inc.", new DateTime(), Milk.LOW_FAT_MILK);
            SetObjectInCertainMethod("set_Food", _methodsShopReg, _objShopReg, milk);
            Milk resultMilk = (Milk)GetObjectFromCertainMethod("get_Food", _methodsShopReg, _objShopReg);
            Assert.AreEqual(resultMilk, milk);
        }

        [TestMethod]
        public void GetQuantityTest()
        {
            long quantity = (long)GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _objShopReg);
            Assert.AreEqual(3L, quantity);
        }

        [TestMethod]
        public void SetQuantityTest()
        {
            SetObjectInCertainMethod("set_Quantity", _methodsShopReg, _objShopReg, 10L);
            long resultQuantity = (long)GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _objShopReg);
            Assert.AreEqual(10L, resultQuantity);
        }

        [TestMethod]
        public void AddQuantityTest()
        {
            long quantity = (long)GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _objShopReg);
            long difference = 5L;
            SetObjectInCertainMethod("AddQuantity", _methodsShopReg, _objShopReg, difference);
            long resultQuantity = (long)GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _objShopReg);
            Assert.AreEqual(quantity + difference, resultQuantity);
        }

        [TestMethod]
        public void SubtractQuantityTest()
        {
            long quantity = (long)GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _objShopReg);
            long difference = 5L;
            SetObjectInCertainMethod("SubtractQuantity", _methodsShopReg, _objShopReg, difference);
            long resultQuantity = (long)GetObjectFromCertainMethod("get_Quantity", _methodsShopReg, _objShopReg);
            Assert.AreEqual(quantity - difference, resultQuantity);
        }

        [TestMethod]
        public void GetPriceTest()
        {
            long resultPrice = (long)GetObjectFromCertainMethod("get_Price", _methodsShopReg, _objShopReg);
            Assert.AreEqual(100L, resultPrice);
        }

        [TestMethod]
        public void SetPriceTest()
        {
            SetObjectInCertainMethod("set_Price", _methodsShopReg, _objShopReg, 200L);
            long resultPrice = (long)GetObjectFromCertainMethod("get_Price", _methodsShopReg, _objShopReg);
            Assert.AreEqual(200L, resultPrice);
        }
    }
}

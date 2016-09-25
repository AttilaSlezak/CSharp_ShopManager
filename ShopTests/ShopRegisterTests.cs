using System;
using System.Reflection;
using Shop;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            // Shop testShop = new Shop("Food Store", "101st Corner Street", "George Warren");
            _testMilk = MilkFactory.NewLongLifeMilk(101L, Milk.LITER, "Plain Milk inc.", DateTime.Now.AddDays(1), Milk.WHOLE_MILK);
            
            Type typeShop = typeof(Shop);
            Type[] typeShopReg = typeShop.GetNestedTypes(BindingFlags.NonPublic);
            ConstructorInfo constShopReg = typeShopReg[0].GetConstructors()[0];
            _objShopReg = constShopReg.Invoke(new object[] { _testMilk, 3, 100});
        }

        [TestCleanup]
        public void TearDown()
        {
            _testMilk = null;
            _objShopReg = null;
        }

        private object GetObjectFromCertainMethod(string methodName)
        {
            object result = null;
            foreach (MethodInfo oneMethod in _methodsShopReg)
            {
                if (oneMethod.Name == methodName)
                {
                    result = oneMethod.Invoke(_objShopReg, new object[] { });
                    break;
                }
            }
            return result;
        }

        private void SetObjectInCertainMethod(string methodName, object newObj)
        { 
            foreach (MethodInfo oneMethod in _methodsShopReg)
            {
                if (oneMethod.Name == methodName)
                {
                    oneMethod.Invoke(_objShopReg, new object[] { newObj });
                    break;
                }
            }
        }

        [TestMethod]
        public void GetMilkTest()
        {
            Milk milk = (Milk)GetObjectFromCertainMethod("get_Milk");
            Assert.AreEqual(_testMilk, milk);
        }

        [TestMethod]
        public void SetMilkTest()
        {
            Milk milk = MilkFactory.NewSemiLongLifeMilk(201L, Milk.HALF_LITER, "Plain Milk inc.", new DateTime(), Milk.LOW_FAT_MILK);
            SetObjectInCertainMethod("set_Milk", milk);
            Milk resultMilk = (Milk)GetObjectFromCertainMethod("get_Milk");
            Assert.AreEqual(resultMilk, milk);
        }

        [TestMethod]
        public void GetQuantityTest()
        {
            int quantity = (int)GetObjectFromCertainMethod("get_Quantity");
            Assert.AreEqual(3, quantity);
        }

        [TestMethod]
        public void SetQuantityTest()
        {
            SetObjectInCertainMethod("set_Quantity", 10);
            int resultQuantity = (int)GetObjectFromCertainMethod("get_Quantity");
            Assert.AreEqual(10, resultQuantity);
        }

        [TestMethod]
        public void AddQuantityTest()
        {
            SetObjectInCertainMethod("AddQuantity", 5);
            int resultQuantity = (int)GetObjectFromCertainMethod("get_Quantity");
            Assert.AreEqual(8, resultQuantity);
        }

        [TestMethod]
        public void SubtractQuantityTest()
        {
            SetObjectInCertainMethod("SubtractQuantity", 2);
            int resultQuantity = (int)GetObjectFromCertainMethod("get_Quantity");
            Assert.AreEqual(1, resultQuantity);
        }

        [TestMethod]
        public void GetPriceTest()
        {
            int resultPrice = (int)GetObjectFromCertainMethod("get_Price");
            Assert.AreEqual(100, resultPrice);
        }

        [TestMethod]
        public void SetPriceTest()
        {
            SetObjectInCertainMethod("set_Price", 200);
            int resultPrice = (int)GetObjectFromCertainMethod("get_Price");
            Assert.AreEqual(200, resultPrice);
        }
    }
}

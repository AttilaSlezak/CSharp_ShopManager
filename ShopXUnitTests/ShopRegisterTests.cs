using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shop;

namespace ShopXUnitTests
{
    public class ShopRegisterTests : IDisposable
    {
        private MethodInfo[] _methodsShopReg = typeof(Shop.Shop).GetNestedTypes(BindingFlags.NonPublic)[0].GetMethods();
        private Milk _testMilk;
        private Object _objShopReg;

        public ShopRegisterTests()
        {
            _testMilk = new Milk(101L, Milk.LITER, "Plain Milk inc.", DateTime.Now.AddDays(1), Milk.WHOLE_MILK);

            Type typeShop = typeof(Shop.Shop);
            Type[] typeShopReg = typeShop.GetNestedTypes(BindingFlags.NonPublic);
            ConstructorInfo constShopReg = typeShopReg[0].GetConstructors()[0];
            _objShopReg = constShopReg.Invoke(new object[] { _testMilk, 3, 100 });
        }

        public void Dispose()
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

        [Fact]
        public void GetMilkTest()
        {
            Milk milk = (Milk)GetObjectFromCertainMethod("get_Milk");
            Assert.Equal(_testMilk, milk);
        }

        [Fact]
        public void SetMilkTest()
        {
            Milk milk = new Milk(201L, Milk.HALF_LITER, "Plain Milk inc.", new DateTime(), Milk.LOW_FAT_MILK);
            SetObjectInCertainMethod("set_Milk", milk);
            Milk resultMilk = (Milk)GetObjectFromCertainMethod("get_Milk");
            Assert.Equal(resultMilk, milk);
        }

        [Fact]
        public void GetQuantityTest()
        {
            int quantity = (int)GetObjectFromCertainMethod("get_Quantity");
            Assert.Equal(3, quantity);
        }

        [Fact]
        public void SetQuantityTest()
        {
            SetObjectInCertainMethod("set_Quantity", 10);
            int resultQuantity = (int)GetObjectFromCertainMethod("get_Quantity");
            Assert.Equal(10, resultQuantity);
        }

        [Fact]
        public void AddQuantityTest()
        {
            SetObjectInCertainMethod("AddQuantity", 5);
            int resultQuantity = (int)GetObjectFromCertainMethod("get_Quantity");
            Assert.Equal(8, resultQuantity);
        }

        [Fact]
        public void SubtractQuantityTest()
        {
            SetObjectInCertainMethod("SubtractQuantity", 2);
            int resultQuantity = (int)GetObjectFromCertainMethod("get_Quantity");
            Assert.Equal(1, resultQuantity);
        }

        [Fact]
        public void GetPriceTest()
        {
            int resultPrice = (int)GetObjectFromCertainMethod("get_Price");
            Assert.Equal(100, resultPrice);
        }

        [Fact]
        public void SetPriceTest()
        {
            SetObjectInCertainMethod("set_Price", 200);
            int resultPrice = (int)GetObjectFromCertainMethod("get_Price");
            Assert.Equal(200, resultPrice);
        }
    }
}

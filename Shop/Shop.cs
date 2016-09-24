using System;
using System.Collections;
using System.Text;

namespace Shop
{
    public class Shop
    {
        private string _name;
        private string _address;
        private string _owner;
        private Hashtable _foodCounter;
        
        public string Name { get { return _name; }}
        public string Address { get { return _address; }}
        public string Owner { get { return _owner; }}

        public Shop(string name, string address, string owner, Hashtable foodCounter)
        {
            _name = name;
            _address = address;
            _owner = owner;
            _foodCounter = foodCounter;
        }

        public Shop(string name, string address, string owner) : this(name, address, owner, new Hashtable())
        {
            
        }

        private bool IsThereAnyCertainFood(Type typeSubClass)
        {
            foreach (ShopRegister oneShopReg in _foodCounter.Values)
            {
                if (typeSubClass.IsInstanceOfType(oneShopReg.Food) && oneShopReg.Quantity > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsThereAnyMilk()
        {
            return IsThereAnyCertainFood(typeof(Milk));
        }

        public bool IsThereAnyCheese()
        {
            return IsThereAnyCertainFood(typeof(Cheese));
        }

        public void ReplenishFoodCounter(long barcode, long quantity)
        {
            ShopRegister shopReg = (ShopRegister)_foodCounter[barcode];
            shopReg.AddQuantity(quantity);
        }

        public void AddNewFoodToFoodCounter(Food food, long quantity, long price)
        {
            ShopRegister shopReg = new ShopRegister(food, quantity, price);
            _foodCounter.Add(food.Barcode, shopReg);
        }

        public void RemoveFoodFromFoodCounter(long barcode)
        {
            _foodCounter.Remove(barcode);
        }

        public void BuyFood(long barCode, long quantity)
        {
            ShopRegister shopReg = (ShopRegister)_foodCounter[barCode];
            if (shopReg != null)
            {
                shopReg.SubtractQuantity(quantity);
            }
        }

        class ShopRegister
        {
            private Food _food;
            private long _quantity;
            private long _price;

            public Food Food { get { return _food; } set { _food = value; } }
            public long Quantity { get { return _quantity; } set { _quantity = value; } }
            public long Price { get { return _price; } set { _price = value; } }

            public ShopRegister(Food food, long quantity, long price)
            {
                _food = food;
                _quantity = quantity;
                _price = price;
            }

            public void AddQuantity(long quantity)
            {
                _quantity += quantity;
            }

            public void SubtractQuantity(long quantity)
            {
                _quantity -= quantity;
            }
        }
    }
}
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
        private Hashtable _milkCounter;
        
        public string Name { get { return _name; }}
        public string Address { get { return _address; }}
        public string Owner { get { return _owner; }}

        public Shop(string name, string address, string owner, Hashtable milkCounter)
        {
            _name = name;
            _address = address;
            _owner = owner;
            _milkCounter = milkCounter;
        }

        public Shop(string name, string address, string owner) : this(name, address, owner, new Hashtable())
        {
            
        }

        public bool IsThereAnyMilk()
        {
            return _milkCounter.Count > 0;
        }

        public void ReplenishMilkCounter(Milk milk)
        {
            ShopRegister shopReg = (ShopRegister)_milkCounter[milk.Barcode];
            if (shopReg == null)
            {
                shopReg = new ShopRegister(milk, 1, 100);
                _milkCounter.Add(milk.Barcode, shopReg);
            }
            else
            {
                shopReg.AddQuantity(1);
            }
        }

        public Milk BuyMilk(long barCode)
        {
            ShopRegister shopReg = (ShopRegister)_milkCounter[barCode];
            if (shopReg != null)
            {
                shopReg.SubtractQuantity(1);
                return shopReg.Milk;
            }
            return null;
        }

        class ShopRegister
        {
            private Milk _milk;
            private int _quantity;
            private int _price;

            public Milk Milk { get { return _milk; } set { _milk = value; } }
            public int Quantity { get { return _quantity; } set { _quantity = value; } }
            public int Price { get { return _price; } set { _price = value; } }

            public ShopRegister(Milk milk, int quantity, int price)
            {
                _milk = milk;
                _quantity = quantity;
                _price = price;
            }

            public void AddQuantity(int quantity)
            {
                _quantity += quantity;
            }

            public void SubtractQuantity(int quantity)
            {
                _quantity -= quantity;
            }
        }
    }
}
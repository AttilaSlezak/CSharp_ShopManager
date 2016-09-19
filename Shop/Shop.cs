using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Shop
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

        public void FillUpMilkCounter(Milk milk)
        {
            _milkCounter.Add(milk.BarCode, milk);
        }

        public Milk BuyMilk(long barCode)
        {
            Milk result = (Milk)_milkCounter[barCode];
            _milkCounter.Remove(barCode);
            return result;
        }
    }
}
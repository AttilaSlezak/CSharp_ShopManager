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
        private int _flag;
        
        public string Name { get { return _name; }}
        public string Address { get { return _address; }}
        public string Owner { get { return _owner; }}

        public Shop(string name, string address, string owner, Hashtable milkCounter)
        {
            _name = name;
            _address = address;
            _owner = owner;
            _milkCounter = milkCounter;
            _flag = milkCounter.Count - 1;
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
            _milkCounter.Add(++_flag, milk);
        }

        public Milk BuyMilk()
        {
            Milk result = (Milk)_milkCounter[_flag];
            _milkCounter.Remove(_flag--);
            return result;
        }
    }
}
using System;
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
        private Milk[] _milkCounter;
        private int _flag;

        public Shop(string name, string address, string owner, Milk[] milkCounter)
        {
            _name = name;
            _address = address;
            _owner = owner;
            _milkCounter = milkCounter;
            _flag = milkCounter.Length - 1;
        }

        public string Name { get { return _name; }}
        public string Address { get { return _address; }}
        public string Owner { get { return _owner; }}
        
        public bool IsThereAnyMilk()
        {
            return _flag >= 0;
        }

        public Milk BuyMilk()
        {
            return _milkCounter[_flag--];
        }
    }
}
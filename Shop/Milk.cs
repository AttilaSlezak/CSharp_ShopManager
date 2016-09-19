using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Milk
    {
        public const int LITER = 1000;
        public const int HALF_LITER = 500;
        public const int GLASS = 200;
        public const double WHOLE_MILK = 2.8;
        public const double LOW_FAT_MILK = 1.5;

        private int _cubicCapacity;
        private string _producer;
        private DateTime _bestBefore;
        private double _fatContent;
        private long _price;

        public Milk(int cubicCapacity, String producer, DateTime bestBefore, double fatContent, long price)
        {
            _cubicCapacity = cubicCapacity;
            _producer = producer;
            _bestBefore = bestBefore;
            _fatContent = fatContent;
            _price = price;
        }

        public int CubicCapacity { get { return _cubicCapacity; }}
        public string Producer { get { return _producer; }}
        public DateTime BestBefore { get { return _bestBefore; }}
        public double FatContent { get { return _fatContent; }}
        public long Price { get { return _price; }}

        public bool CheckStillUnderGuarantee()
        {
            return _bestBefore.CompareTo(DateTime.Now) == 1 ? true : false;
        }

        public override string ToString()
        {
            return "Milk{" +
                "cubic capacity: " + _cubicCapacity + " ml" +
                ", producer: '" + _producer + "'" +
                ", best before: " + _bestBefore +
                ", fat content: " + _fatContent +
                ", price: " + _price + " forint(s)" +
                '}';
        }
    }
}

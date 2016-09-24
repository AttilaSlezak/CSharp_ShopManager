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

        private long _barcode;
        private int _cubicCapacity;
        private string _producer;
        private DateTime _bestBefore;
        private double _fatContent;

        public long Barcode { get { return _barcode; } }
        public int CubicCapacity { get { return _cubicCapacity; }}
        public string Producer { get { return _producer; }}
        public DateTime BestBefore { get { return _bestBefore; }}
        public double FatContent { get { return _fatContent; }}
           
        public Milk(long barcode, int cubicCapacity, String producer, DateTime bestBefore, double fatContent)
        {
            _barcode = barcode;
            _cubicCapacity = cubicCapacity;
            _producer = producer;
            _bestBefore = bestBefore;
            _fatContent = fatContent;
        }

        public bool CheckStillUnderGuarantee()
        {
            return _bestBefore.CompareTo(DateTime.Now) == 1 ? true : false;
        }

        public override string ToString()
        {
            return "Milk{" +
                "barcode: " + _barcode +
                ", cubic capacity: " + _cubicCapacity + " ml" +
                ", producer: '" + _producer + "'" +
                ", best before: " + _bestBefore +
                ", fat content: " + _fatContent + "%}";
        }
    }
}

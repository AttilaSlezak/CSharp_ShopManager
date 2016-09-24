using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public abstract class Milk : Food
    {
        public const int LITER = 1000;
        public const int HALF_LITER = 500;
        public const int GLASS = 200;
        public const double WHOLE_MILK = 2.8;
        public const double LOW_FAT_MILK = 1.5;

        private int _cubicCapacity;
        private double _fatContent;

        public int CubicCapacity { get { return _cubicCapacity; }}
        public double FatContent { get { return _fatContent; }}
           
        public Milk(long barcode, int cubicCapacity, string producer, DateTime bestBefore, double fatContent) : base(barcode, producer, bestBefore)
        {
            _cubicCapacity = cubicCapacity;
            _fatContent = fatContent;
        }

        public override string ToString()
        {
            return "Milk{" +
                "barcode: " + Barcode +
                ", cubic capacity: " + _cubicCapacity + " ml" +
                ", producer: '" + Producer + "'" +
                ", best before: " + BestBefore +
                ", fat content: " + _fatContent + "%}";
        }
    }
}

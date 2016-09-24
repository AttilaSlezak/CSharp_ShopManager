using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Cheese
    {
        private long _barcode;
        private double _weight;
        private string _producer;
        private DateTime _bestBefore;
        private double _fatContent;

        public long Barcode { get { return _barcode; } }
        public double Weight { get { return _weight; } }
        public string Producer { get { return _producer; } }
        public DateTime BestBefore { get { return _bestBefore; } }
        public double FatContent { get { return _fatContent; } }

        public Cheese(long barcode, double weight, String producer, DateTime bestBefore, double fatContent)
        {
            _barcode = barcode;
            _weight = weight;
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
            return "Cheese{" +
                "barcode: " + _barcode +
                ", weight: " + _weight + " kg" +
                ", producer: '" + _producer + "'" +
                ", best before: " + _bestBefore +
                ", fat content: " + _fatContent + "%}";
        }
    }
}

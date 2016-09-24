using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public abstract class Food
    {
        private long _barcode;
        private string _producer;
        private DateTime _bestBefore;

        public long Barcode { get { return _barcode; } }
        public string Producer { get { return _producer; } }
        public DateTime BestBefore { get { return _bestBefore; } }

        public Food(long barcode, string producer, DateTime bestBefore)
        {
            _barcode = barcode;
            _producer = producer;
            _bestBefore = bestBefore;
        }

        public bool CheckStillUnderGuarantee()
        {
            return _bestBefore.CompareTo(DateTime.Now) == 1 ? true : false;
        }

        public override string ToString()
        {
            return "Food{" +
                "barcode: " + _barcode +
                ", producer: '" + _producer + "'" +
                ", best before: " + _bestBefore + "}";
        }
    }
}
}

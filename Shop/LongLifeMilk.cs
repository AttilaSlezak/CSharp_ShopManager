using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class LongLifeMilk : Milk
    {
        public LongLifeMilk(long barcode, int cubicCapacity, String producer, DateTime bestBefore, double fatContent) 
            : base(barcode, cubicCapacity, producer, bestBefore, fatContent)
        {

        }
    }
}

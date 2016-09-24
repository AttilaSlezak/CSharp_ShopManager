using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public abstract class MilkFactory
    {
        public static Milk NewLongLifeMilk(long barcode, int cubicCapacity, String producer, DateTime bestBefore, double fatContent)
        {
            return new LongLifeMilk(barcode, cubicCapacity, producer, bestBefore, fatContent);
        }

        public static Milk NewSemiLongLifeMilk(long barcode, int cubicCapacity, String producer, DateTime bestBefore, double fatContent)
        {
            return new SemiLongLifeMilk(barcode, cubicCapacity, producer, bestBefore, fatContent);
        }
    }
}

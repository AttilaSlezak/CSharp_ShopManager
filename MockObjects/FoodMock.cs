using Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockObjects
{
    public class FoodMock : Food
    {
        public FoodMock(long barcode, string producer, DateTime bestBefore) : base(barcode, producer, bestBefore)
        {
        }
    }
}

using Shop;
using System;


namespace MockObjects
{
    public class MilkMock : Milk
    {
        public MilkMock(long barcode, int cubicCapacity, string producer, DateTime bestBefore, double fatContent)
            : base(barcode, cubicCapacity, producer, bestBefore, fatContent)
        {
        }
    }
}

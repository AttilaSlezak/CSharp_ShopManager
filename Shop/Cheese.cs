using System;


namespace Shop
{
    public class Cheese : Food
    {
        private double _weight;
        private double _fatContent;

        public double Weight { get { return _weight; } }
        public double FatContent { get { return _fatContent; } }

        public Cheese(long barcode, double weight, string producer, DateTime bestBefore, double fatContent) : base(barcode, producer, bestBefore)
        {
            _weight = weight;
            _fatContent = fatContent;
        }

        public override string ToString()
        {
            return "Cheese{" +
                "barcode: " + Barcode +
                ", weight: " + _weight + " g" +
                ", producer: '" + Producer + "'" +
                ", best before: " + BestBefore +
                ", fat content: " + _fatContent + "%}";
        }
    }
}

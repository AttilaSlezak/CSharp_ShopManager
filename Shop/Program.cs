using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Milk milk = new Milk(1000, "Alföld tej", new DateTime(2017, 1, 1), 2.8, 215);
            Console.WriteLine(milk.checkStillUnderGuarantee());
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberGenerators
{
    class Program
    {
        static void Main(string[] args)
        {
            //Poisson poisson1 = new Poisson(10, 100000);
            Exponential exponential1 = new Exponential(1.5, 1000000);

            Console.WriteLine(exponential1);
            Console.ReadKey();
        }
    }
}

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
            Distribution poisson = new Distribution(100, 1000000);

            foreach (KeyValuePair<int, int> pair in poisson.FrequencyDictionary)
            {
                Console.WriteLine($"Number: {pair.Key} || Frequency: {pair.Value} || P(X = {pair.Key}) = {pair.Value / Convert.ToDouble(poisson.NumberOfEvents)}");
            }
            Console.WriteLine($"E(X)/mean = {poisson.Mean}");
            Console.WriteLine($"Variance = {poisson.Variance}");
            Console.ReadKey();
        }
    }
}

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
            //Poisson poisson1 = new Poisson(20, 10000000);
            //Exponential exponential1 = new Exponential(0.5, 10000);
            //Exponential exponential2 = new Exponential(1, 1000000);
            //Exponential exponential3 = new Exponential(1.5, 1000000);

            //Console.WriteLine(poisson1);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.Write($"Lambda: {poisson1.Lambda}\nNumber of events: {poisson1.NumberOfEvents}\nMultiplied by: {poisson1.Multiple}");
            //Console.WriteLine();
            //Console.WriteLine(exponential2);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine(exponential3);
            SimulatePoisson(5, 1000000, 4);
            Console.ReadKey();
        }

        public static void SimulatePoisson(double lambda, int numberOfExperiments, int interval)
        {
            // The poisson resembles how the distribution should be.
            Poisson poissonDistribution = new Poisson(lambda, numberOfExperiments, interval);

            // The exponential distribution provides the basis for the simulation. 
            Exponential exponentialDistribution = new Exponential(lambda, numberOfExperiments);

            // Maybe this should be a method of exponential.
            List<double> simulationResults = exponentialDistribution.SimulatePoissonDistribution(interval);

            // Create Poisson object out of the simulation's results to re-use methods, just the number of experiments
            Poisson poissonSimulation = new Poisson(lambda * interval, simulationResults.Count, simulationResults);

            Console.WriteLine(poissonDistribution);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(poissonSimulation);
        }
    }
}

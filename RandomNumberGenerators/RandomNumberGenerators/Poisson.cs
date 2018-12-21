using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberGenerators
{
    class Poisson : Distribution
    {
        // Properties
        public double T { get; }

        public Poisson(double lambda, int numberOfEvents, double t = 1) : base(lambda, numberOfEvents)
        {
            T = t;
        }

        /// <summary>
        /// Knuth's algorithm used for generating a random poisson value based on a given lambda.
        /// </summary>
        /// <returns>An integer random value matching the poisson distribution.</returns>
        protected override double GenerateRadomVariable()
        {
            int k = 0;
            double u;
            double p = 1;
            double L = Math.Exp(-Lambda);

            do
            {
                k++;
                u = rng.NextDouble();
                p *= u;
            } while (p > L);

            return k - 1;
        }

        protected override double CalculateVariance()
        {
            double sum = 0;
            foreach (int value in GeneratedDistributionValues)
            {
                sum += Math.Pow(value - Mean, 2);
            }
            return sum / Convert.ToDouble(NumberOfEvents);
        }

        protected override double CalculateMean()
        {
            return GeneratedDistributionValues.Average();
        }
    }
}

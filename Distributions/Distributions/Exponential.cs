using System;
using System.Collections.Generic;

namespace Distributions
{
    class Exponential : Distribution
    {
        public Exponential(double lambda, int numberOfEvents) : base(lambda, numberOfEvents)
        { }
        protected override double CalculateMean()
        {
            // Beta = Lambda^-1 (see wiki page)
            return 1 / Lambda;
        }

        protected override double CalculateVariance()
        {
            // Beta^2 = (Lambda^-1)^2 = Lambda^(-1 * 2) = Lambda^-2 (see wiki page)
            return Math.Pow(Lambda, -2);
        }

        protected override double GenerateRadomVariable()
        {
            double x;
            double u = rng.NextDouble();

            // Inversion of the CDF according to stack overflow.
            x = Math.Log(1 - u) / -Lambda;
            return x;
        }

        public List<double> SimulatePoissonDistribution(int interval)
        {
            // Can generate a list of doubles for this simulation
            List<double> results = new List<double>();
            int count = 0;
            double interArrivalSum = 0;
            foreach (double value in GeneratedDistributionValues)
            {
                // Keep track of a count per number until the sum + number value is greater than the interval size.
                // then reset the counter.
                if (interArrivalSum + value < interval)
                {
                    count++;
                    interArrivalSum += value;
                }
                else
                {
                    results.Add(count);
                    interArrivalSum = 0;
                    count = 0;
                }
            }
            // Pass the list of doubles to our original dictionary generation method
            // and return it.
            return results;
        }
    }
}

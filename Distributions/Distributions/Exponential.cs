using System;
using System.Collections.Generic;

namespace Distributions
{
    class Exponential : Distribution
    {
        public Exponential(double lambda, int numberOfEvents, int multiple) : base(lambda, numberOfEvents, multiple)
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

        /// <summary>
        /// For an exponential distribution we can calculate
        /// the PMF value by taking the difference of the CDF
        /// values.
        /// 
        /// EX. P(X <= 3) - P(X <= 2) = P(X = 3)
        /// </summary>
        /// <param name="x">An integer, the value of interest to calculate the PMF value for.</param>
        /// <returns>A double, the probability of x occuring.</returns>
        public override double CalculatePMF(double x)
        {
            // Offset by one to skip 0 = 0.
            x += 1;
            // Scale it back down as the keys (x) values passed
            // to this method are scaled up by * Multiple.
            x /= Convert.ToDouble(Multiple);
            
            return CalculateCDF(x) - CalculateCDF(x - 1 / Convert.ToDouble(Multiple));
        }
        public double CalculateCDF(double x)
        {
            // According to the wiki page: 1 - e^-(lambda * x)
            return 1 - Math.Exp(-Lambda * x);
        }

        protected override double GenerateRadomVariable()
        {
            double x;
            double u = rng.NextDouble();

            // Inversion of the CDF according to stack overflow.
            x = Math.Log(1 - u) / -Lambda;
            return x;
        }

        public List<double> SimulatePoissonDistribution(double interval)
        {
            // Can generate a list of doubles for this simulation
            List<double> results = new List<double>();
            int count = 0;
            double interArrivalSum = 0;

            // Can check the total arrival time, if the last interval
            // is broken, we can add numbers until this matches a new full
            // interval and then resume regular execution of the simmulation.
            List<double> distributionValues = GeneratedDistributionValues;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions
{
    class Poisson : Distribution
    {
        /// <summary>
        /// If someone gave in T for the interval, lambda gets multiplied by t
        /// to represent the expected value / mean for a preiod of t given an 
        /// expected value (lambda) over an original interval.
        /// </summary>
        /// <param name="t"></param>
        public Poisson(double lambda, int numberOfEvents, double t = 1) : base(lambda * t, numberOfEvents)
        { }

        /// <summary>
        /// Constructor to be used for Poisson simulations.
        /// As the simulation can make use of all methods that the distribution does except that
        /// it comes with its own set of double values.
        /// </summary>
        /// <param name="lambda"></param>
        /// <param name="numberOfEvents"></param>
        /// <param name="distributionValues"></param>
        public Poisson(double lambda, int numberOfEvents, List<double> distributionValues) : base(lambda, numberOfEvents, distributionValues)
        { }

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

        /// <summary>
        /// Will calculate and return the probability for a random variable
        /// X taking on the value x.
        /// 
        /// Thus essentially calculating the probability that with given para-
        /// meters, lambda (expected value) and T (interval), x will occur.
        /// </summary>
        /// <param name="x"></param>
        /// <returns>The probability that x will occur given lambda and T.</returns>
        public override double CalculatePMF(double x)
        {
            // In my program Lambda already includes T (the interval unit multiple)
            // Numerator would be e^-(lambda * T) * (Lambda * T)^x
            double numerator = Math.Exp(-Lambda) * Math.Pow(Lambda, x);
            // Denominator = x!
            double denominator = 1;
            for (int i = 1; i <= x; i++)
            {
                denominator *= i;
            }
            return numerator / denominator;
        }
    }
}

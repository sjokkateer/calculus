using System;

namespace RandomNumberGenerators
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
            Console.Write($"{x}, ");
            return x;
        }
    }
}

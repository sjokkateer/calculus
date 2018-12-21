using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberGenerators
{
    class Distribution
    {
        // Variabels
        private Random rng;
        private List<int> generatedPoissonValues;
        private SortedDictionary<int, int> frequencyDictionary;

        // Properties
        public double Lambda { get; }
        public int NumberOfEvents { get; }
        public double T { get; }
        public List<int> GeneratedPoissonValues
        {
            get
            {
                // Return a copy to the user.
                return new List<int>(generatedPoissonValues);
            }
        }
        public SortedDictionary<int, int> FrequencyDictionary
        {
            get
            {
                // Return a copy to the user.
                return new SortedDictionary<int, int>(frequencyDictionary);
            }
        }
        public double Mean { get; }
        public double Variance { get; }

        public Distribution(double lambda, int numberOfEvents, double t = 1)
        {
            rng = new Random();

            Lambda = lambda;
            NumberOfEvents = numberOfEvents;
            T = t;

            generatedPoissonValues = GeneratePoissonDistribution();
            Mean = generatedPoissonValues.Average();
            double sum = 0;
            foreach (int value in generatedPoissonValues)
            {
                sum += Math.Pow(value - Mean, 2);
            }
            Variance = sum / NumberOfEvents;

            // Create a key/value mapping to be used for histograms.
            frequencyDictionary = CreateFrequencyDictionary();
        }

        private List<int> GeneratePoissonDistribution()
        {
            List<int> distribution = new List<int>();
            for (int i = 0; i < NumberOfEvents; i++)
            {
                distribution.Add(GenerateRandomPoissonVariable());
            }
            return distribution;
        }

        private SortedDictionary<int, int> CreateFrequencyDictionary()
        {
            SortedDictionary<int, int> resultFrequencyDictionary = new SortedDictionary<int, int>();
            foreach (int value in GeneratedPoissonValues)
            {
                if (resultFrequencyDictionary.ContainsKey(value))
                {
                    resultFrequencyDictionary[value]++;
                }
                else
                {
                    resultFrequencyDictionary[value] = 1;
                }
            }
            return resultFrequencyDictionary;
        }

        /// <summary>
        /// Generates a random Poisson variable as by Knuth's algorithm.
        /// </summary>
        /// <returns>Returns an integer representing the random variable x or k.</returns>
        private int GenerateRandomPoissonVariable()
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
    }
}

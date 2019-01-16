using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions
{
    abstract class Distribution
    {
        // Variabels
        protected Random rng;
        private List<double> generatedValues;
        private SortedDictionary<int, int> frequencyDictionary;
        private double lambda;
        private int numberOfEvents;
        private int multiple;

        // Properties
        public double Lambda
        {
            get { return lambda; }
            set
            {
                if (value >= 0)
                {
                    lambda = value;
                }
                else
                {
                    throw new InvalidLambdaException("Please enter a value >= 0 for lambda.");
                }
            }
        }
        public int NumberOfEvents
        {
            get { return numberOfEvents; }
            private set
            {
                if (value > 0 )
                {
                    numberOfEvents = value;
                }
                else
                {
                    throw new InvalidNumberOfTrialsException("Please enter a value > 0 for the number of trials for the distribution.");
                }
            }
        }
        public int Multiple
        {
            get { return multiple; }
            private set
            {
                if (value > 0)
                {
                    multiple = value;
                }
                else
                {
                    throw new InvalidInterArrivalValueException("Please enter a value > 0 for the interval (T).");
                }
            }
        }

        /// <summary>
        /// Returns a copy of the list of integers generated for the distribution.
        /// </summary>
        public List<double> GeneratedDistributionValues
        {
            get
            {
                // Return a copy to the user.
                return new List<double>(generatedValues);
            }
        }
        /// <summary>
        /// Returns a copy of the dictionary of (x, frequency) pairs generated for the distribution.
        /// </summary>
        public SortedDictionary<int, int> FrequencyDictionary
        {
            get
            {
                // Return a copy to the user.
                return new SortedDictionary<int, int>(frequencyDictionary);
            }
            protected set
            {
                frequencyDictionary = value;
            }
        }
        public double Mean { get; protected set; }
        public double Variance { get; protected set; }
        /// <summary>
        /// Returns the square root of the variance.
        /// </summary>
        public double StDev
        {
            get
            {
                return Math.Sqrt(Variance);
            }
        }

        /// <summary>
        /// Creates a new random object used to generate uniform random numbers from which a distribution will derive its own random numbers.
        /// 
        /// Will generate 'numberOfEvents' random values and add them into a list.
        /// Will create a sorted dictionary based on the list of generated random values that represents a sort of frequency table.
        /// </summary>
        /// <param name="lambda">A double, the expected value/mean value.</param>
        /// <param name="numberOfEvents">A natural number, representing the number of trials or number of random numbers to be generated.</param>
        public Distribution(double lambda, int numberOfEvents, int multiple = 1, List<double> generatedDistributionValues = null)
        {
            // Initialization
            rng = new Random();
            Lambda = lambda;
            NumberOfEvents = numberOfEvents;
            Multiple = multiple;

            // Generation
            if (generatedDistributionValues == null)
            {
                generatedValues = GenerateDistribution();
            }
            else
            {
                generatedValues = generatedDistributionValues;
            }
            frequencyDictionary = CreateFrequencyDictionary(generatedValues);

            // Calculation
            Mean = CalculateMean();
            Variance = CalculateVariance();
        }

        /// <summary>
        /// Creates a list of integer results for 
        /// NumberOfEvents calls to the method that will
        /// generate a random variable.
        /// </summary>
        /// <returns>A list of integers, holding the results to N calls of generate random variable.</returns>
        private List<double> GenerateDistribution()
        {
            {
                List<double> distribution = new List<double>();
                for (int i = 0; i < NumberOfEvents; i++)
                {
                    distribution.Add(GenerateRadomVariable());
                }
                return distribution;
            }
        }

        /// <summary>
        /// Creates a sorted dictionary of key, value pairs for which
        /// the key represents the integer value x, k (generated by generate random variable calls)
        /// and the value will represent the count/frequency of occurence of the key in the list of integers.
        /// </summary>
        /// <returns>A sorted dictionary of int keys and int values, representing the frequency "table" of the distribution.</returns>
        protected SortedDictionary<int, int> CreateFrequencyDictionary(List<double> distributionValues)
        {
            SortedDictionary<int, int> resultFrequencyDictionary = new SortedDictionary<int, int>();
            int newValue;
            foreach (double value in distributionValues)
            {
                newValue = Convert.ToInt32(Math.Truncate(value * Multiple));

                if (resultFrequencyDictionary.ContainsKey(newValue))
                {
                    resultFrequencyDictionary[newValue]++;
                }
                else
                {
                    resultFrequencyDictionary[newValue] = 1;
                }
            }
            return resultFrequencyDictionary;
        }

        /// <summary>
        /// Abstract protected method that can be overridden by classes that inherit
        /// from the distribution class. Two classes that will be inheriting from this
        /// abstract base class are Poisson and Exponential, these will both have a unique
        /// way of generating a random variable, while the distribution concept is the same.
        /// </summary>
        /// <returns>
        /// Returns an integer representing the random variable x or k for the 
        /// respective distribution.
        /// </returns>
        protected abstract double GenerateRadomVariable();
        protected abstract double CalculateVariance();
        protected abstract double CalculateMean();
        public abstract double CalculatePMF(double x);
        /// <summary>
        /// Generates a string format of the frequency dictionary appended by the mean, variance and standard deviation
        /// for this specific distribution.
        /// </summary>
        /// <returns>A string representing an overview of the distribution.</returns>
        public override string ToString()
        {
            string result = "";
            foreach(KeyValuePair<int, int> pair in frequencyDictionary)
            {
                // Will create a string looking like:
                // Number: 1 || Frequency: 23 || P(X = 1) = 0.0231
                // For every key in the sorted dictionary.
                result += $"Number: {pair.Key} || Frequency: {pair.Value} || P(X = {pair.Key}) = {pair.Value / Convert.ToDouble(NumberOfEvents)}\n";
            }
            // Append additional information as the mean, variance and stdev of the distribution.
            result += $"Mean: {Mean}\n";
            result += $"Variance: {Variance}\n";
            result += $"Standard Deviation: {StDev}";

            return result;
        }
    }
}

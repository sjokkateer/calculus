using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Distributions
{
    public partial class Form1 : Form
    {
        Chart selectedChart;
        ListBox selectedListBox;
        Distribution selectedDistribution;

        public Form1()
        {
            InitializeComponent();
        }

        private void poissonDistributionBtn_Click(object sender, EventArgs e)
        {
            double lambda = Convert.ToDouble(lambdaTbx.Text);
            int numberOfTrials = Convert.ToInt32(numbOfTrialsTbx.Text);

            double interArrivalTime;
            bool interValGiven = double.TryParse(interArrivalTbx.Text, out interArrivalTime);

            if (!interValGiven)
            {
                interArrivalTime = 1;
            }

            Poisson poissonDistribution = new Poisson(lambda, numberOfTrials, interArrivalTime);
            selectedDistribution = poissonDistribution;
            selectedChart = poissonDistributionChart;
            selectedListBox = poissonToStringListBox;
            CreateHistogram();
            CreatePMFPlot();
            PopulateSelectedListBox();
        }

        /// <summary>
        /// Populates the selected list box with respecive key/value pairs
        /// frequencies and the propability of it occuring based on frequency / number of events.
        /// 
        /// The last 3 values in the list box are the Mean,
        /// Variance and Standard Deviation for the selected distribution.
        /// </summary>
        private void PopulateSelectedListBox()
        {
            selectedListBox.Items.Clear();
            foreach (KeyValuePair<int, int> pair in selectedDistribution.FrequencyDictionary)
            {
                selectedListBox.Items.Add($"Number: {pair.Key} || Frequency: {pair.Value} || P(X = {pair.Key}) = {pair.Value / Convert.ToDouble(selectedDistribution.NumberOfEvents)}");
            }
            selectedListBox.Items.Add("");
            selectedListBox.Items.Add($"Mean: {selectedDistribution.Mean}");
            selectedListBox.Items.Add($"Variance: {selectedDistribution.Variance}");
            selectedListBox.Items.Add($"Standard Deviation: {selectedDistribution.StDev}");
        }


        private void CreateHistogram()
        {
            Console.WriteLine($"{selectedChart}");
            selectedChart.Series[0].Points.Clear();
            foreach (KeyValuePair<int, int> pair in selectedDistribution.FrequencyDictionary)
            {
                selectedChart.Series[0].Points.AddXY(pair.Key, pair.Value);
            }
        }

        private void CreatePMFPlot()
        {
            double scaledPMF = 0;

            selectedChart.Series[1].Points.Clear();
            foreach (KeyValuePair<int, int> pair in selectedDistribution.FrequencyDictionary)
            {
                // Have to scale the PMF towards the number of events entered.
                scaledPMF = selectedDistribution.CalculatePMF(pair.Key) * selectedDistribution.NumberOfEvents;
                Console.WriteLine($"P(X = {pair.Key}) = {scaledPMF}");
                selectedChart.Series[1].Points.AddXY(pair.Key, scaledPMF);
            }
        }

        private void exponentialDistributionBtn_Click(object sender, EventArgs e)
        {
            double lambda = Convert.ToDouble(lambdaTbx.Text);
            int numberOfTrials = Convert.ToInt32(numbOfTrialsTbx.Text);

            Exponential exponentialDistribution = new Exponential(lambda, numberOfTrials);
            selectedDistribution = exponentialDistribution;
            selectedChart = exponentialDistributionChart;
            selectedListBox = exponentialToStringListBox;
            CreateHistogram();
            CreatePMFPlot();
            PopulateSelectedListBox();
        }

        private void simulationBtn_Click(object sender, EventArgs e)
        {
            double lambda = Convert.ToDouble(lambdaTbx.Text);
            int numberOfTrials = Convert.ToInt32(numbOfTrialsTbx.Text);

            double interArrivalTime;
            bool interValGiven = double.TryParse(interArrivalTbx.Text, out interArrivalTime);

            if (!interValGiven)
            {
                interArrivalTime = 1;
            }

            // The poisson resembles how the distribution should be.
            Poisson poissonDistribution = new Poisson(lambda, numberOfTrials, interArrivalTime);
            selectedDistribution = poissonDistribution;
            selectedChart = poissonDistributionChart;
            selectedListBox = poissonToStringListBox;
            CreateHistogram();
            CreatePMFPlot();
            PopulateSelectedListBox();

            // The exponential distribution provides the basis for the simulation. 
            Exponential exponentialDistribution = new Exponential(lambda, numberOfTrials);
            // Incremented the number of bins to represent the exponential distribution a bit better.
            selectedDistribution = exponentialDistribution;
            selectedChart = exponentialDistributionChart;
            selectedListBox = exponentialToStringListBox;
            CreateHistogram();
            CreatePMFPlot();
            PopulateSelectedListBox();

            List<double> simulationResults = exponentialDistribution.SimulatePoissonDistribution(interArrivalTime);
            
            // Create Poisson object out of the simulation's results to re-use methods, just the number of experiments
            Poisson poissonSimulation = new Poisson(lambda * interArrivalTime, simulationResults.Count, simulationResults);
            selectedChart = simulationChart;
            selectedDistribution = poissonSimulation;
            selectedListBox = simulationToStringListBox;
            CreateHistogram();
            CreatePMFPlot();
            PopulateSelectedListBox();
        }

        private void poissonToStringLb_Click(object sender, EventArgs e)
        {

        }
    }
}

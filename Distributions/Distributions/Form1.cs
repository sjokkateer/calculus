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
        Label selectedLabel;
        Distribution selectedDistribution;
        Exponential exponentialDistribution;

        public Form1()
        {
            InitializeComponent();
            binIncrementTooltip.SetToolTip(scalingTrackBar, "Please take into account that increasing the number of bins with a small \nnumber of trials will decrease the accuracy at some point.");
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
            selectedLabel = poissonStatisticsLb;
            CreateHistogram();
            CreatePMFPlot();
            ShowStatistics();
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
            double scaledKey;

            selectedListBox.Items.Clear();
            foreach (KeyValuePair<int, int> pair in selectedDistribution.FrequencyDictionary)
            {
                scaledKey = pair.Key / Convert.ToDouble(selectedDistribution.Multiple);
                selectedListBox.Items.Add($"Number: {scaledKey} || Frequency: {pair.Value} || P(X = {scaledKey}) = {Math.Round(pair.Value / Convert.ToDouble(selectedDistribution.NumberOfEvents), 3)}");
            }
        }

        private void ShowStatistics()
        {
            selectedLabel.Text = $"Mean: {Math.Round(selectedDistribution.Mean, 3)}\n";
            selectedLabel.Text += $"Variance: {Math.Round(selectedDistribution.Variance, 3)}\n";
            selectedLabel.Text += $"Standard Deviation: {Math.Round(selectedDistribution.StDev, 3)}";
        }

        private void CreateHistogram()
        {
            selectedChart.Series[0].Points.Clear();
            double scaledKey;
            foreach (KeyValuePair<int, int> pair in selectedDistribution.FrequencyDictionary)
            {
                scaledKey = pair.Key / Convert.ToDouble(selectedDistribution.Multiple);
                selectedChart.Series[0].Points.AddXY(scaledKey, pair.Value);
            }
        }

        private void CreatePMFPlot()
        {
            double scaledPMF = 0;
            double scaledKey;

            selectedChart.Series[1].Points.Clear();
            foreach (KeyValuePair<int, int> pair in selectedDistribution.FrequencyDictionary)
            {
                // Have to scale the PMF towards the number of events entered.
                scaledPMF = selectedDistribution.CalculatePMF(pair.Key) * selectedDistribution.NumberOfEvents;
                scaledKey = pair.Key / Convert.ToDouble(selectedDistribution.Multiple);
                selectedChart.Series[1].Points.AddXY(scaledKey, scaledPMF);
            }
        }

        private void exponentialDistributionBtn_Click(object sender, EventArgs e)
        {
            double lambda = Convert.ToDouble(lambdaTbx.Text);
            int numberOfTrials = Convert.ToInt32(numbOfTrialsTbx.Text);

            // the value will be at least 1 if the trackbar is not moved 10^(1 - 1) would result in multiple of 1 etc.
            double binMultiple = Math.Pow(10, scalingTrackBar.Value - 1);
            exponentialDistribution = new Exponential(lambda, numberOfTrials, Convert.ToInt32(binMultiple));

            selectedDistribution = exponentialDistribution;
            selectedChart = exponentialDistributionChart;
            selectedListBox = exponentialToStringListBox;
            selectedLabel = exponentialStatisticsLb;
            CreateHistogram();
            CreatePMFPlot();
            ShowStatistics();
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
            selectedLabel = poissonStatisticsLb;
            CreateHistogram();
            CreatePMFPlot();
            ShowStatistics();
            PopulateSelectedListBox();

            // The exponential distribution provides the basis for the simulation. 
            // the value will be at least 1 if the trackbar is not moved 10^(1 - 1) would result in multiple of 1 etc.
            double binMultiple = Math.Pow(10, scalingTrackBar.Value - 1);
            exponentialDistribution = new Exponential(lambda, numberOfTrials, Convert.ToInt32(binMultiple));
            // Incremented the number of bins to represent the exponential distribution a bit better.
            selectedDistribution = exponentialDistribution;
            selectedChart = exponentialDistributionChart;
            selectedListBox = exponentialToStringListBox;
            selectedLabel = exponentialStatisticsLb;
            CreateHistogram();
            CreatePMFPlot();
            ShowStatistics();
            PopulateSelectedListBox();

            List<double> simulationResults = exponentialDistribution.SimulatePoissonDistribution(interArrivalTime);
            
            // Create Poisson object out of the simulation's results to re-use methods, just the number of experiments
            Poisson poissonSimulation = new Poisson(lambda * interArrivalTime, simulationResults.Count, simulationResults);
            selectedChart = simulationChart;
            selectedDistribution = poissonSimulation;
            selectedListBox = simulationToStringListBox;
            selectedLabel = simulationStatisticsLb;
            CreateHistogram();
            CreatePMFPlot();
            ShowStatistics();
            PopulateSelectedListBox();
        }
    }
}

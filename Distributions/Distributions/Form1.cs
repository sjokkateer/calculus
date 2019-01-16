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
            try
            {
                double lambda;
                bool isLambdaGiven = double.TryParse(lambdaTbx.Text, out lambda);

                int numberOfTrials;
                bool isNumberOfTrialsGiven = int.TryParse(numbOfTrialsTbx.Text, out numberOfTrials);

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
            catch (InvalidLambdaException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidNumberOfTrialsException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidInterArrivalValueException ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        /// <summary>
        /// Updates the selected distribution's corresponding labels
        /// within the chart area and displays the mean, variance, and
        /// standard deviation of the distribution.
        /// </summary>
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

            try
            {
                double lambda;
                bool isLambdaGiven = double.TryParse(lambdaTbx.Text, out lambda);

                int numberOfTrials;
                bool isNumberOfTrialsGiven = int.TryParse(numbOfTrialsTbx.Text, out numberOfTrials);

                // the value will be at least 10 if the trackbar is not moved 10^(trackbar value) would result in multiple of 1 etc.
                double binMultiple = Math.Pow(10, scalingTrackBar.Value);
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
            catch (InvalidLambdaException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidNumberOfTrialsException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidInterArrivalValueException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simulationBtn_Click(object sender, EventArgs e)
        {
            double lambda;
            bool isLambdaGiven = double.TryParse(lambdaTbx.Text, out lambda);

            int numberOfTrials;
            bool isNumberOfTrialsGiven = int.TryParse(numbOfTrialsTbx.Text, out numberOfTrials);

            double interArrivalTime;
            bool interValGiven = double.TryParse(interArrivalTbx.Text, out interArrivalTime);

            if (!interValGiven)
            {
                interArrivalTime = 1;
            }

            if (isLambdaGiven)
            {
                if (isNumberOfTrialsGiven)
                {
                    try
                    {
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
                        // the value will be at least 10 if the trackbar is not moved 10^(trackbar value) would result in multiple of 1 etc.
                        double binMultiple = Math.Pow(10, scalingTrackBar.Value);
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the number of trials.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a value for lambda.");
            }
        }

        /// <summary>
        /// Handles validation for the input of the lambda textbox
        /// to be a digit, backspace or 1 single decimal point.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lambdaTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If either character input is a digit or backspace, allow the
            // input, and also allow single decimal point input for lamda's
            // textbox.
            bool isNotDigitOrBackSpace = isNotNumericOrBackspace(e);
            if (isNotDigitOrBackSpace)
            {
                // If it is neither of aforementioned, check if it's the first and
                // only decimal point being input.

                // If the actual character input is a decimal point, convert the event sender
                // to a textbox object and locate if there is already a . inside the text property
                // if not, allow the . to be entered, otherwise we don't handle the character.
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') < 0))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = isNotDigitOrBackSpace;
            }
        }

        /// <summary>
        /// Helper method that generalizes character valdidation for digits
        /// and backspaces.
        /// </summary>
        /// <param name="e"></param>
        /// <returns>
        /// a true or false value indicating if the character should be
        /// marked handled or not.
        /// </returns>
        private bool isNotNumericOrBackspace(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)8)
            {
                return false;
            }
            return true;
        }

        private void numbOfTrialsTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
           e.Handled = isNotNumericOrBackspace(e);
        }

        private void interArrivalTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = isNotNumericOrBackspace(e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace eXpressionParsing
{
    public partial class Form1 : Form
    {
        Parser expressionParser;

        // Two standard lists, that will function as storage,
        // in case an expression was parsed but the person,
        // wants to zoom around the plot.

        public Form1()
        {
            InitializeComponent();
        }

        private void parseBtn_Click(object sender, EventArgs e)
        {
            string expression = expressionTbx.Text;
            if (expression == string.Empty)
            {
                MessageBox.Show("Please enter an expression to parse.");
            }
            else
            {
                expressionParser = new Parser(expression);
                expressionParser.Parse();
                humanReadableLbl.Text = $"Expression: {expressionParser.ToString()}";

                CrearteChart();
            }
        }

        private void CrearteChart()
        {
            expressionChart.Series.Clear();

            double xMin = -5;
            double xMax = 5;

            double yMin = -10;
            double yMax = 10;

            double step = 0.01;
            double result;

            expressionChart.Series.Add("Expression");
            expressionChart.Series["Expression"].ChartType = SeriesChartType.Line;
            
            expressionChart.Series["Expression"].ChartArea = "ChartArea1";

            expressionChart.ChartAreas["ChartArea1"].AxisX.Minimum = xMin;
            expressionChart.ChartAreas["ChartArea1"].AxisX.Maximum = xMax;

            expressionChart.ChartAreas["ChartArea1"].AxisY.Minimum = yMin;
            expressionChart.ChartAreas["ChartArea1"].AxisY.Maximum = yMax;

            for (double i = xMin; i <= xMax; i += step)
            {
                result = expressionParser.CalculateForX(i);
                if (!double.IsInfinity(result) && !double.IsNaN(result))
                {
                    expressionChart.Series["Expression"].Points.AddXY(i, result);
                }
            }
        }
    }
}

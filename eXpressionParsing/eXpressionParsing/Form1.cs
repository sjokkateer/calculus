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
                humanReadableLbl.Text = expressionParser.ToString();
                CrearteChart();
            }
        }

        private void CrearteChart()
        {
            double xMin = -50;
            double xMax = 50;
            double yMin = -300;
            double yMax = 300;
            double step = 0.01;

            for (double i = xMin; i <= xMax; i += step)
            {
                expressionParser.CalculateForX(i);
            }
        }
    }
}

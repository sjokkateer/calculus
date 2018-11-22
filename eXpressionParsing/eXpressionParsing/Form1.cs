using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.IO;

namespace eXpressionParsing
{
    public delegate double CalculateForXHandler(double x);

    public partial class Form1 : Form
    {
        // The delegate that will handle the calculations when asked to
        // create a chart.
        private CalculateForXHandler calculator;

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
                // Basic parsing method
                ParseExpression(expression);

                // Do all other additional stuff.
                try
                {
                    // Assign the calculate for x to the delegate.
                    calculator = new CalculateForXHandler(expressionParser.CalculateForX);
                    // Then plot the chart.
                    CrearteChart();

                    // This could be extended to prompt for a file name.
                    CreateGraph("expression", expressionParser.DotFileGraph());

                    // Placed deep in here such that there will still be
                    // made a png picture representation of the entered
                    // expression.
                    if (expressionChart.Series["Expression"].Points.Count < 1)
                    {
                        throw new InvalidExpressionException($"{expressionParser.ToString()} is not a valid expression!");
                    }
                }
                catch (InvalidExpressionException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Method that can be re-used to parse an entered expression.
        /// </summary>
        /// <param name="expression"></param>
        private void ParseExpression(string expression)
        {
            expressionParser = new Parser(expression);
            try
            {
                expressionParser.Parse();
                humanReadableLbl.Text = $"Expression: {expressionParser.ToString()}";
            }
            catch (InvalidNumberException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidArgumentTypeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidFactorialArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Method that is responsible for creating the chart
        /// and plot.
        /// </summary>
        private void CrearteChart()
        {
            expressionChart.Series.Clear();

            double xMin = -5;
            double xMax = 5;

            double yMin = -10;
            double yMax = 15;

            double step = 0.0001;
            double result;

            expressionChart.Series.Add("Expression");
            expressionChart.Series["Expression"].ChartType = SeriesChartType.Point;
            expressionChart.Series["Expression"].MarkerSize = 2;

            expressionChart.Series["Expression"].ChartArea = "ChartArea1";

            expressionChart.ChartAreas["ChartArea1"].AxisX.Minimum = xMin;
            expressionChart.ChartAreas["ChartArea1"].AxisX.Maximum = xMax;

            expressionChart.ChartAreas["ChartArea1"].AxisY.Minimum = yMin;
            expressionChart.ChartAreas["ChartArea1"].AxisY.Maximum = yMax;

            for (double i = xMin; i <= xMax; i += step)
            {
                result = calculator(i);
                if (!double.IsInfinity(result) && !double.IsNaN(result))
                {
                    expressionChart.Series["Expression"].Points.AddXY(i, result);
                }
            }
        }
        
        /// <summary>
        /// Method responsible for creating the image via the
        /// graphViz program, that is based on the input of
        /// a .dot file.
        /// </summary>
        /// <param name="dotFileName">A string, someFileName.dot
        /// that is used to create a .dot file that represents
        /// the expression in graph form.</param>
        private void CreateGraph(string dotFileName, string fileContent)
        {
            CreateDotFile(dotFileName, fileContent);

            // Maybe move this code into a new method that can be re-used later.
            Process dot = new Process();
            dot.StartInfo.FileName = "dot.exe";
            dot.StartInfo.Arguments = $"-Tpng -o{dotFileName}.png {dotFileName}.dot";
            dot.Start();
            dot.WaitForExit();
            graphPictureBox.ImageLocation = $"{dotFileName}.png";
        }

        /// <summary>
        /// Is the method that is responsible for the writing to the .dot file.
        /// 
        /// Writes the expression into the .dot file as a tree in the corresponding
        /// format (the .dot file requires).
        /// </summary>
        private void CreateDotFile(string fileName, string fileContent)
        {
            FileStream fs = new FileStream($"{fileName}.dot", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                if (sw != null)
                {
                    sw.WriteLine("graph calculus {");
                    sw.WriteLine("\tnode [ fontname = \"Arial\" ]");
                    sw.Write(fileContent);
                    sw.WriteLine("}");
                    sw.Close();
                }
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

        private void differentiateBtn_Click(object sender, EventArgs e)
        {
            // Always parse the expression such that any newly
            // entered expression can be differentiated and displayed.
            string expression = expressionTbx.Text;

            
            if (expression == string.Empty)
            {
                MessageBox.Show("Please enter an expression to differentiate.");

            }
            else
            {
                // Parse only if an expression is entered.
                ParseExpression(expression);

                // Differentiate the expression.
                expressionParser.Differentiate();

                // Display the derivative in text.
                derivativeLb.Text = $"Derivative: {}";

                // Assign the method to calculate the x'es for the derivative of the expression.
                calculator = new CalculateForXHandler(expressionParser.CalculateForXDerivative);
                // Plot the values.
                CrearteChart();

                // Create a graph of the analytical derivative.
                CreateGraph("derivative", expressionParser.DotFileGraphDerivative());
            }
        }
    }
}

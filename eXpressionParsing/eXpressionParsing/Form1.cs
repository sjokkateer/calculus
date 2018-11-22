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

        Operand expressionRoot;
        Operand derivativeExpressionRoot;

        // Two standard lists, that will function as storage,
        // in case an expression was parsed but the person,
        // wants to zoom around the plot.

        public Form1()
        {
            InitializeComponent();
            Text = "Complex Calculus And Much More. Application";
            WindowState = FormWindowState.Maximized;
        }

        private void Parse()
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
                    calculator = new CalculateForXHandler(expressionRoot.Calculate);
                    // Then plot the chart.

                    expressionChart.Series.Clear();
                    string seriesName = "Expression";
                    CrearteChart(seriesName);

                    // Placed deep in here such that there will still be
                    // made a png picture representation of the entered
                    // expression.
                    if (expressionChart.Series[seriesName].Points.Count < 1)
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

        private void Differentiate()
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
                Parse();

                // Differentiate the expression.
                derivativeExpressionRoot = expressionRoot.Differentiate();

                // Display the derivative in text.
                derivativeLb.Text = $"Derivative: {derivativeExpressionRoot.ToString()}";

                // Assign the method to calculate the x'es for the derivative of the expression.
                calculator = new CalculateForXHandler(derivativeExpressionRoot.Calculate);
                CrearteChart("Analytical Derivative");

                // Plot Newton's difference quotient as well.
                calculator = new CalculateForXHandler(DifferenceQuotient);
                CrearteChart("Difference Quotient");
            }
        }

        private double DifferenceQuotient(double x)
        {
            double changeInX = 0.000001;

            // f(x + changeInX) - f(x) / changeInX
            return (expressionRoot.Calculate(x + changeInX) - expressionRoot.Calculate(x)) / changeInX;
        }

        /// <summary>
        /// Method that can be re-used to parse an entered expression.
        /// 
        /// Is split from the Parse method to allow Differentiate to be
        /// run individually, thus first parsing the expression and then
        /// differentiating it.
        /// </summary>
        /// <param name="expression">Takes in a string in Polish pre-fix 
        /// notation representing a valid expression.</param>
        private void ParseExpression(string expression)
        {
            //
            //
            // !!! Could also just assign the expression to a live expression object. !!!
            //
            //
            expressionParser = new Parser(expression);
            try
            {
                // Parse and assign the returned expression root.
                expressionRoot = expressionParser.Parse();
                expressionLb.Text = $"Expression: {expressionRoot.ToString()}";
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
        private void CrearteChart(string seriesName)
        {
            double xMin = -5;
            double xMax = 5;

            double yMin = -10;
            double yMax = 15;

            expressionChart.ChartAreas["ChartArea1"].AxisX.Minimum = xMin;
            expressionChart.ChartAreas["ChartArea1"].AxisX.Maximum = xMax;

            expressionChart.ChartAreas["ChartArea1"].AxisY.Minimum = yMin;
            expressionChart.ChartAreas["ChartArea1"].AxisY.Maximum = yMax;

            CreateSeries(xMin, xMax, seriesName);
        }
        
        private void CreateSeries(double xMin, double xMax, string seriesName)
        {
            expressionChart.Series.Add(seriesName);
            expressionChart.Series[seriesName].ChartType = SeriesChartType.Point;
            expressionChart.Series[seriesName].MarkerSize = 2;

            expressionChart.Series[seriesName].ChartArea = "ChartArea1";

            double step = 0.0001;
            double result;
            for (double i = xMin; i <= xMax; i += step)
            {
                result = calculator(i);
                if (!double.IsInfinity(result) && !double.IsNaN(result))
                {
                    expressionChart.Series[seriesName].Points.AddXY(i, result);
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

        /// <summary>
        /// Labels all the nodes in the expression
        /// in a BFS manner such that a graph can be
        /// made for it.
        /// </summary>
        /// <param name="expressionRoot">Is the root of the expression to be numbered.</param>
        private void NumberOperands(Operand expressionRoot)
        {
            List<Operand> queue = new List<Operand>();

            Operand currentOperand = expressionRoot;

            // Add the root as the first item in the queue.
            queue.Add(currentOperand);

            // Label the root as the first node (node1) and add it to
            // the queue.
            int nodeCounter = 1;
            while (currentOperand != null)
            {
                // Process the first operand of the queue.
                currentOperand.NodeNumber = nodeCounter;

                // Check what type of operator/operand to add its children to the queue.
                if (currentOperand is BinaryOperator)
                {
                    queue.Add(((BinaryOperator)currentOperand).LeftSuccessor);
                    queue.Add(((BinaryOperator)currentOperand).RightSuccessor);
                }
                else if (currentOperand is UnaryOperator)
                {
                    queue.Add(((UnaryOperator)currentOperand).LeftSuccessor);
                }
                // Remove the recently processed operand from the queue and try to
                // Obtain the next if there is one.
                queue.RemoveAt(0);
                // Check if it was not a single operand as input expression.
                if (queue.Count > 0)
                {
                    currentOperand = queue[0];
                }
                else
                {
                    currentOperand = null;
                }
                nodeCounter++;
            }
        }

        /// <summary>
        /// Based on a radio button selection, the graph
        /// of either the expression or the derivative will
        /// be drawn.
        /// 
        /// Process will always parse the expression and plot it
        /// for both the expression and derivative.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void processBtn_Click(object sender, EventArgs e)
        {
            if (parseRbtn.Checked)
            {
                Parse();
                
                // Label the nodes and create its graph.
                NumberOperands(expressionRoot);
                CreateGraph("expression", expressionRoot.NodeLabel());
            }
            else if (differentiateRbtn.Checked)
            {
                Differentiate();

                // Number the nodes in the derivative expression tree.
                NumberOperands(derivativeExpressionRoot);
                // Create a graph of the analytical derivative.
                CreateGraph("derivative", derivativeExpressionRoot.NodeLabel());
            }
        }
    }
}

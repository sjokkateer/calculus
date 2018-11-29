using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.IO;
using System.Drawing;

namespace eXpressionParsing
{
    public delegate double CalculateForXHandler(double x);

    public partial class Form1 : Form
    {
        // The delegate that will handle the calculations when asked to
        // create a chart.
        private CalculateForXHandler calculator;

        private Parser expressionParser;

        private Operand expressionRoot;
        private Operand derivativeExpressionRoot;

        private RectangleF rect;
        private double lower;
        private double upper;
        private double sum;

        private double xMin;
        private double xMax;
        private double yMin;
        private double yMax;

        // Two standard lists, that will function as storage,
        // in case an expression was parsed but the person,
        // wants to zoom around the plot.

        public Form1()
        {
            InitializeComponent();
            Text = "Complex Calculus And Much More. Application";
            WindowState = FormWindowState.Maximized;

            xMin = -10;
            xMax = 10;
            yMin = -2;
            yMax = 2;
        }

        private void Parse(Exception error)
        {
            string expression = expressionTbx.Text;
            if (expression == string.Empty)
            {
                throw error;
            }
            else
            {
                // Basic parsing method
                ParseExpression(expression);
            }
        }

        /// <summary>
        /// Simple method that represents Newton's difference quotient.
        /// 
        /// Will calculate (f(x + h) - f(x)) / h and return this value
        /// </summary>
        /// <param name="x">A double, representing the current 
        /// value for x.</param>
        /// <returns>(f(x + h) - f(x)) / h</returns>
        private double DifferenceQuotient(double x)
        {
            double changeInX = 0.000001;

            // (f(x + changeInX) - f(x)) / changeInX
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
            expressionParser = new Parser(expression);

            // Parse and assign the returned expression root.
            expressionRoot = expressionParser.Parse();
            expressionRoot = expressionRoot.Simplify();
            expressionLb.Text = $"Expression: {expressionRoot.ToString()}";
        }

        private void CrearteChart(string seriesName)
        {
            expressionChart.ChartAreas[0].AxisX.Minimum = xMin;
            expressionChart.ChartAreas[0].AxisX.Maximum = xMax;

            expressionChart.ChartAreas[0].AxisY.Minimum = yMin;
            expressionChart.ChartAreas[0].AxisY.Maximum = yMax;

            CreateSeries(xMin, xMax, yMin, yMax, seriesName);
        }

        private void CreateSeries(double xMin, double xMax, double yMin, double yMax, string seriesName, SeriesChartType chartType = SeriesChartType.Point)
        {
            int seriesIndex = expressionChart.Series.IndexOf(seriesName);
            if (seriesIndex >= 0)
            {
                // Series name already exists so just redo 
                // calculation on an empty set of points
                expressionChart.Series.RemoveAt(seriesIndex);
            }
            // Create a new one series.
            expressionChart.Series.Add(seriesName);

            expressionChart.Series[seriesName].ChartType = chartType;
            expressionChart.Series[seriesName].MarkerSize = 2;

            expressionChart.Series[seriesName].ChartArea = "ChartArea1";

            double step = 0.0001;
            double result;
            for (double i = xMin; i <= xMax; i += step)
            {
                result = calculator(i);
                if (result >= yMin && result <= yMax)
                {
                    if (!double.IsInfinity(result) && !double.IsNaN(result))
                    {
                        expressionChart.Series[seriesName].Points.AddXY(i, result);
                    }
                }
            }
            if (expressionChart.Series[seriesName].Points.Count < 1)
            {
                throw new InvalidExpressionException($"{expressionRoot.ToString()} is not a valid expression!");
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

        private void CreateGraphOfFunction(Operand expressionRoot, string fileName)
        {
            // Label the right expression tree and create the graph of it.
            NumberOperands(expressionRoot);
            CreateGraph(fileName, expressionRoot.NodeLabel());
        }

        private void ResetAll()
        {
            // Reset all series from the chart as well.
            expressionChart.Series.Clear();

            expressionChart.Invalidate();
            expressionLb.Text = "Expression: ";
            derivativeLb.Text = $"Derivative: ";
            areaLb.Text = "Estimated area: ";
        }

        private void ObtainAxisBoundaries()
        {
            string minX = xMinTbx.Text;
            string maxX = xMaxTbx.Text;
            string minY = yMinTbx.Text;
            string maxY = yMaxTbx.Text;

            if (minX != string.Empty)
            {
                double.TryParse(minX, out xMin);
            }

            if (maxX != string.Empty)
            {
                double.TryParse(maxX, out xMax);
            }

            if (minY != string.Empty)
            {
                double.TryParse(minY, out yMin);
            }

            if (maxY != string.Empty)
            {
                double.TryParse(maxY, out yMax);
            }
        }

        private void processBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Reset method
                ResetAll();

                // Try to obtain min and max values for the axis.
                ObtainAxisBoundaries();

                Console.WriteLine($"X Min {xMin}, Max {xMax} || Y Min {yMin}, Max {yMax}");

                // For now the entered expression must always be parsed first.
                Parse(new NoExpressionEnteredException("Please enter an expression to parse."));

                // For now always make a plot of the entered expression
                // as it is used for regular parsing, the derivative and for the integral.

                // In the future we could sub an event and unsub this basic method
                // for the taylor polynomials etc if we need to.
                calculator = new CalculateForXHandler(expressionRoot.Calculate);
                CrearteChart("Expression");

                if (parseRbtn.Checked)
                {
                    CreateGraphOfFunction(expressionRoot, "expression");
                }
                else if (differentiateRbtn.Checked)
                {
                    // Calculate the derivative and simplify all the excessive x^1, x*0 x+0, etc.
                    // before creating a chart and graph of it.
                    derivativeExpressionRoot = expressionRoot.Differentiate();
                    derivativeExpressionRoot = derivativeExpressionRoot.Simplify();

                    // Display the derivative in text.
                    derivativeLb.Text = $"Derivative: {derivativeExpressionRoot.ToString()}";

                    // Assign the method to calculate the x'es for the derivative of the expression.
                    calculator = new CalculateForXHandler(derivativeExpressionRoot.Calculate);
                    CrearteChart("Analytical Derivative");

                    // Plot Newton's difference quotient as well.
                    calculator = new CalculateForXHandler(DifferenceQuotient);
                    CrearteChart("Difference Quotient");

                    CreateGraphOfFunction(derivativeExpressionRoot, "derivative");
                }
                else if (integralRbtn.Checked)
                {
                    bool isADouble = double.TryParse(intervalATbx.Text, out lower);
                    bool isBDouble = double.TryParse(intervalBTbx.Text, out upper);

                    if (!isADouble || !isBDouble)
                    {
                        throw new InvalidArgumentTypeException("Please enter valid numbers for the range from a through b");
                    }
                    calculator = new CalculateForXHandler(expressionRoot.Calculate);
                    expressionChart.Refresh();
                    areaLb.Text += $"{Math.Round(sum, 2)} square units.";
                }
            }
            catch (InvalidExpressionException ex)
            {
                MessageBox.Show(ex.Message);
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
            catch (NoExpressionEnteredException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (UndefinedExpressionException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void integralRbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (integralInputPanel.Visible == false)
            {
                integralInputPanel.Visible = true;
            }
        }

        private void parseRbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (integralInputPanel.Visible == true)
            {
                integralInputPanel.Visible = false;
            }
        }

        private void differentiateRbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (integralInputPanel.Visible == true)
            {
                integralInputPanel.Visible = false;
            }
        }

        // Only allow digits, . and backspace characters as input for the interval for
        // the definite integral.
        private void intervalATbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)8 || e.KeyChar == (char)46 || e.KeyChar == (char)45)
            {
                e.Handled = false;
            }
        }

        // Same story for the upper bound textbox.
        private void intervalBTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)8 || e.KeyChar == (char)46 || e.KeyChar == (char)45)
            {
                e.Handled = false;
            }
        }

        private void expressionChart_Paint(object sender, PaintEventArgs e)
        {
            if (calculator != null)
            {
                if (integralRbtn.Checked)
                {
                    sum = 0;

                    double step = (upper - lower) / Convert.ToDouble(riemannIntervalTb.Text);
                    double result;

                    float l;
                    float r;
                    float t;
                    float b;

                    for (double i = lower; i <= upper; i += step)
                    {
                        result = calculator(i + (step / 2));

                        // If the sum is not already set to infinity.
                        if (!double.IsInfinity(sum))
                        {
                            // We want to add result to the sum for the total surface area.
                            if (!double.IsInfinity(result))
                            {
                                // Positive areas.
                                if (result > 0)
                                {
                                    sum += result;
                                }
                                else
                                {
                                    sum += -1 * result;
                                }
                            }
                            else if (double.IsInfinity(result))
                            {
                                if (result < 0)
                                {
                                    sum = double.NegativeInfinity;
                                }
                                else
                                {
                                    sum = double.PositiveInfinity;
                                }
                            }
                        }

                        if (i >= xMin && i + step <= xMax)
                        {
                            // Plot only the values that are between min and max that the double class allows.
                            if (result >= double.MinValue && result <= double.MaxValue)
                            {
                                // First plot the negative area such that display matches.
                                if (!double.IsInfinity(result) && !double.IsNaN(result))
                                {
                                    // Also if the values are between the boundaries of the chart's axis
                                    l = (float)expressionChart.ChartAreas[0].AxisX.ValueToPixelPosition(i);
                                    r = (float)expressionChart.ChartAreas[0].AxisX.ValueToPixelPosition(i + step);
                                    if (result > 0)
                                    {
                                        t = (float)expressionChart.ChartAreas[0].AxisY.ValueToPixelPosition(result);
                                        b = (float)expressionChart.ChartAreas[0].AxisY.ValueToPixelPosition(0);
                                    }
                                    else
                                    {
                                        t = (float)expressionChart.ChartAreas[0].AxisY.ValueToPixelPosition(0);
                                        b = (float)expressionChart.ChartAreas[0].AxisY.ValueToPixelPosition(result);
                                    }
                                    rect = RectangleF.FromLTRB(l, t, r, b);
                                    using (SolidBrush br = new SolidBrush(Color.Green))
                                    {
                                        e.Graphics.FillRectangle(br, rect.X, rect.Y, rect.Width, rect.Height);
                                    }
                                    e.Graphics.DrawRectangle(Pens.Green, rect.X, rect.Y, rect.Width, rect.Height);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

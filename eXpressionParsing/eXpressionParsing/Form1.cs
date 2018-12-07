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
        private Operand macLaurinRoot;
        private int macLaurinCounter;

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

        private void CreateChart(string seriesName)
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
            List<double> resultSet = new List<double>();

            for (double i = xMin; i <= xMax; i += step)
            {
                result = calculator(i);
                if (result >= yMin && result <= yMax)
                {
                    if (!double.IsInfinity(result))
                    {
                        expressionChart.Series[seriesName].Points.AddXY(i, result);
                    }
                }
                // If there is a legit result value calculate
                // even though it did not fit inside our y boundaries
                // we want to include it in a different set such that 
                // we can make sure the program will only call expressions
                // invalid over a certain interval if it actually is true.
                if (!double.IsNaN(result))
                {
                    resultSet.Add(result);
                }
            }
            if (expressionChart.Series[seriesName].Points.Count == 0)
            {
                if (resultSet.Count == 0)
                {
                    throw new InvalidExpressionException($"{expressionRoot.ToString()} is not a valid expression over this interval!");
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

        private void ParseAndPlotExpressions(string errorMessage)
        {
            // Reset
            ResetAll();

            // Try to obtain min and max values for the axis.
            ObtainAxisBoundaries();

            // For now the entered expression must always be parsed first.
            Parse(new NoExpressionEnteredException(errorMessage));

            // For now always make a plot of the entered expression
            // as it is used for regular parsing, the derivative and for the integral.

            // In the future we could sub an event and unsub this basic method
            // for the taylor polynomials etc if we need to.
            calculator = new CalculateForXHandler(expressionRoot.Calculate);
            CreateChart("Expression");
        }

        private void processBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ParseAndPlotExpressions("Please enter an expression to parse.");

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
                    CreateChart("Analytical Derivative");

                    // Plot Newton's difference quotient as well.
                    calculator = new CalculateForXHandler(DifferenceQuotient);
                    CreateChart("Difference Quotient");

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
                    expressionChart.Refresh(); // Ensure that the pain event is triggrred.
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
            if (intergralGroupBox.Visible == false)
            {
                intergralGroupBox.Visible = true;
            }
        }

        private void parseRbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (intergralGroupBox.Visible == true)
            {
                intergralGroupBox.Visible = false;
            }
        }

        private void differentiateRbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (intergralGroupBox.Visible == true)
            {
                intergralGroupBox.Visible = false;
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

        // Paint event that is responsible for drawing the definite integral
        // or Riemann sum for the entered expression.
        // My method uses the midpoint rule to create it's rectangles.
        private void expressionChart_Paint(object sender, PaintEventArgs e)
        {
            if (calculator != null)
            {
                if (integralRbtn.Checked)
                {
                    try
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

                            // As long as our i is between the x axis min and max, we draw.
                            // Otherwise we only calculate
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
                                            // If the result is larger than the set max value for the y axis
                                            // Assign the max y value to result and plot it such that the 
                                            // painting does not go over the chart axis boundaries.
                                            if (result > yMax)
                                            {
                                                result = yMax;
                                            }
                                            t = (float)expressionChart.ChartAreas[0].AxisY.ValueToPixelPosition(result);
                                            b = (float)expressionChart.ChartAreas[0].AxisY.ValueToPixelPosition(0);
                                        }
                                        else
                                        {
                                            // Same as before, assign the y min to result and draw it.
                                            if (result < yMin)
                                            {
                                                result = yMin;
                                            }
                                            // If the result is negative, we have the upper part of the rectangle to start at 0
                                            // and the rectangle has to be drawn up and until the negative value.
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
                    catch (FormatException)
                    { }
                }
            }
        }

        private Operand CreateMaclaurinTerm(Operand expression, int i)
        {
            // The zero-th order MacLaurin Polynomial is (P0(x)) = 
            // f(0) * (x^0)/0! which simplifies to a constant?
            if (i == 0)
            {
                // We can return calculate and return the function value
                // evaluated in x = 0.
                double functionValue = expression.Calculate(0);
                //Addition test = new Addition();
                //test.LeftSuccessor = new RealNumber(functionValue);
                //test.RightSuccessor = new RealNumber(0.0);
                //return test;
                return new RealNumber(functionValue);
            }
            else
            {
                // Create a term by differentiating the input expression
                // and create according to the input value of i the other
                // terms/parts of the expression.

                // For the returned expression I will set the left successor
                // to always be the nth order derivative (slope value).

                // The expression is differentiated if i != 0.
                // Operand derivative = expression.Differentiate();
                // Calculate the coefficient in a = 0.
                double slope = expression.Calculate(0);
                // If the slope is NaN we pretty much evaluated all possible
                // derivatives (there is no more derivative possible)
                // Thus return 0 such that we can simplify later on.
                if (double.IsNaN(slope))
                {
                    slope = 0;
                }
                Operand resultSlope = new RealNumber(slope);

                Multiplication MacLaurinTerm = new Multiplication();
                MacLaurinTerm.LeftSuccessor = resultSlope;
                Division div = new Division();
                MacLaurinTerm.RightSuccessor = div;
                // Now create the right part of the multiplication (f'i(0) * (x - 0)^i / i!)
                // Create the numerator (x - 0)^i
                Power numerator = new Power();
                numerator.LeftSuccessor = new DependentVariableX();
                numerator.RightSuccessor = new Integer(i);
                // Create the denominator (i)!.
                Factorial denominator = new Factorial();
                denominator.LeftSuccessor = new Integer(i);
                // Add the numerator and denominator into the division Operator.
                div.LeftSuccessor = numerator;
                div.RightSuccessor = denominator;

                return MacLaurinTerm;
            }
        }

        private Operand CreateMacLaurinPolynomial(Addition root, Addition currentTerm, Operand expression, int i, int n)
        {
            if (i == n)
            {
                // return the nth term back up to the calling stack.
                currentTerm.LeftSuccessor = CreateMaclaurinTerm(expression, i);
                currentTerm.RightSuccessor = new RealNumber(0.0);
                return root;
            }
            else
            {
                // else return the ith term of the maclaurin polynomial + the next one.
                // first create and assign term i.
                currentTerm.LeftSuccessor = CreateMaclaurinTerm(expression, i);
                // Assign a 0 value to the right sub expression such that calculations don't crash the program
                // and also the expression as a whole is not changed.
                currentTerm.RightSuccessor = new RealNumber(0.0);
                calculator = new CalculateForXHandler(root.Calculate);
                CreateChart($"MacLaurin {i}");
                
                expression = expression.Differentiate();
                currentTerm.RightSuccessor = new Addition();
                return CreateMacLaurinPolynomial(root, (Addition)currentTerm.RightSuccessor, expression, i + 1, n);
            }
        }

        private void btnAnalyticalMcLaurin_Click(object sender, EventArgs e)
        {
            int n;
            bool isNEntered = int.TryParse(nPolynomialTbx.Text, out n);
            if (isNEntered)
            {
                // First parse the expression, if any is entered.
                ParseAndPlotExpressions("Please enter an expression to use as basis for the MacLaurin Polynomial.");
                // Recursively create the nth MacLaurin polynomial.
                Addition newRoot = new Addition();
                Operand MacLaurinPolynomial = CreateMacLaurinPolynomial(newRoot, newRoot, expressionRoot.Copy(), 0, n);

                // Simplify and plot the final polynomial.
                MacLaurinPolynomial = MacLaurinPolynomial.Simplify();
                calculator = new CalculateForXHandler(MacLaurinPolynomial.Calculate);
                // Plot the final polynomial
                CreateChart($"MacLaurin {n}");

                CreateGraphOfFunction(MacLaurinPolynomial, "macLaurin");
            }
            else
            {
                MessageBox.Show("Please enter a valid N for the nth order MacLaurin Polynomial.");
            }
        }

        /// <summary>
        /// Allows only digits to be input in the textbox and backspace characters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nPolynomialTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
        }

        private void btnQuotientMcLaurin_Click(object sender, EventArgs e)
        {

        }
    }
}


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

        private bool polynomialCoordinates;
        private List<Coordinate> polynomialCoordinatesList;
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
            yMin = -5;
            yMax = 5;

            polynomialCoordinates = false;
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
                expressionParser = new Parser(expression);

                // Parse and assign the returned expression root.
                expressionRoot = expressionParser.Parse();
                expressionRoot = expressionRoot.Simplify();
                expressionLb.Text = $"Expression: {expressionRoot.ToString()}";
            }
        }

        /// <summary>
        /// Simple method that represents Newton's difference quotient.
        /// 
        /// Will calculate (f(x + h) - f(x)) / h and return this value
        /// as a double.
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

            //expressionChart.Series[seriesName].ChartArea = "ChartArea1";

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
                    CreateGraphOfExpression(expressionRoot, "expression");
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

                    CreateGraphOfExpression(derivativeExpressionRoot, "derivative");
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

        private void CreateGraphOfExpression(Operand expressionRoot, string dotFileName)
        {
            Grapher.CreateGraphOfFunction(expressionRoot, dotFileName);
            graphPictureBox.ImageLocation = $"{dotFileName}.png";
        }

        private void btnAnalyticalMcLaurin_Click(object sender, EventArgs e)
        {
            int n;
            bool isNEntered = int.TryParse(nPolynomialTbx.Text, out n);
            if (isNEntered)
            {
                // First parse the expression, if any is entered.
                ParseAndPlotExpressions("Please enter an expression to use as basis for the MacLaurin Polynomial.");
                MacLaurinPolynomial macLaurinPolynomial = new MacLaurinPolynomial(expressionRoot.Copy(), n);
                // Create a graph of the highest order MacLaurin polynomial.
                Operand highestOrderPolynomial = macLaurinPolynomial.GetNthMacLaurinPolynomial(n);
                CreateGraphOfExpression(highestOrderPolynomial, "MacLaurinPolynomialAnalytically");

                // Plot all but the last which we do after the loop.
                for (int i = 0; i < n; i++)
                {
                    calculator = new CalculateForXHandler(macLaurinPolynomial.GetNthMacLaurinPolynomial(i).Calculate);
                    CreateChart($"MacLaurin Polynomial of degree {i}");
                }
                // Since we already used the simplified expression tree of the n-th order MacLaurin polynomial plot it after the loop.
                calculator = new CalculateForXHandler(highestOrderPolynomial.Calculate);
                CreateChart($"MacLaurin Polynomial of degree {n}");
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
            int n;
            bool isNEntered = int.TryParse(nPolynomialTbx.Text, out n);
            if (isNEntered)
            {
                // First parse the expression, if any is entered.
                ParseAndPlotExpressions("Please enter an expression to use as basis for the MacLaurin Polynomial.");
                MacLaurinPolynomial macLaurinPolynomial = new MacLaurinPolynomial(expressionRoot.Copy(), n);
                // Create a graph of the highest order MacLaurin polynomial.
                Operand highestOrderPolynomial = macLaurinPolynomial.GetNthMacLaurinPolynomial(n);
                CreateGraphOfExpression(highestOrderPolynomial, "MacLaurinPolynomialQuotient");

                List<double> xRange = new List<double>();
                double step = 0.0001;

                for (double i = xMin; i <= xMax; i += step)
                {
                    xRange.Add(i);
                }

                List<List<double>> macLaurinValues = macLaurinPolynomial.CalculateMaclaurinPolynomials(xRange, n);
                for (int i = 0; i < macLaurinValues.Count; i++)
                {
                    CreateSeriesFromValues($"Polynomial {i}", xRange, macLaurinValues[i]);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid N for the nth order MacLaurin Polynomial.");
            }
        }
        private void CreateSeriesFromValues(string seriesName, List<double> range, List<double> values, SeriesChartType chartType = SeriesChartType.Point)
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

            for (int i = 0; i < range.Count; i++)
            {
                if (!double.IsInfinity(values[i]))
                {
                    expressionChart.Series[seriesName].Points.AddXY(range[i], values[i]);
                }

            }
        }

        private void plotPolynomialBtn_Click(object sender, EventArgs e)
        {
            if (polynomialCoordinatesList != null)
            {// Create a new solver based on the obtained coordinates.
                SystemSolver s = new SystemSolver(polynomialCoordinatesList);
                Console.WriteLine(s);
                // Get the expression representation of the system.
                // And simplify it where possible.
                Operand poly = s.GetPolynomial().Simplify();
                // Put the expression string in the respective label.
                expressionLb.Text = poly.ToString();
                // Create a graph of the polynomial.
                CreateGraphOfExpression(poly, "n-polynomial");
                // Plot the polynomial.
                calculator = new CalculateForXHandler(poly.Calculate);
                CreateChart("n-polynomial");
                // Set flag back to false not allowing any more extra coordinates.
                polynomialCoordinates = false;
            }
            else
            {
                MessageBox.Show("Please enter coordinates first.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            expressionChart.ChartAreas[0].AxisX.Maximum = xMax;
            expressionChart.ChartAreas[0].AxisX.Minimum = xMin;

            expressionChart.ChartAreas[0].AxisY.Maximum = yMax;
            expressionChart.ChartAreas[0].AxisY.Minimum = yMin;
        }

        private void expressionChart_MouseClick(object sender, MouseEventArgs e)
        {
            if (polynomialCoordinates)
            {
                // Ensure the coordinates are between the x min/max and y, such that no point is taken outside the displayed grid.
                double x = expressionChart.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                double y = expressionChart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);

                // Create a coordinate and add it to the list for the polynomial.
                Coordinate clickedCoordinate = new Coordinate(x, y);
                polynomialCoordinatesList.Add(clickedCoordinate);
                coordinatesListBox.Items.Add(clickedCoordinate);

                expressionChart.Series["PlaceHolder"].Points.AddXY(x, y);
            }
        }

        private void coordinatesBtn_Click(object sender, EventArgs e)
        {
            // Refresh the list of coordinates.
            polynomialCoordinatesList = new List<Coordinate>();
            coordinatesListBox.Items.Clear();
            expressionChart.Series["PlaceHolder"].Points.Clear();

            //for (int i = 0; i < expressionChart.Series.Count; i++)
            //{
            //    expressionChart.Series[i].Points.Clear();
            //}
            
            // Set flag to true, allowing clicked coordinates to be added to the list.
            polynomialCoordinates = true;
        }
    }
}


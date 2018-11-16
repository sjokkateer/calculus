using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.IO;

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

                // This could be extended to prompt for a file name.
                CreateGraph("expression.dot");
            }
        }

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
                result = expressionParser.CalculateForX(i);
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
        private void CreateGraph(string dotFileName)
        {
            CreateDotFile(dotFileName);

            Process dot = new Process();
            dot.StartInfo.FileName = "dot.exe";
            dot.StartInfo.Arguments = "-Tpng -oexpression.png expression.dot";
            dot.Start();
            dot.WaitForExit();
            graphPictureBox.ImageLocation = "expression.png";
        }

        /// <summary>
        /// Is the method that is responsible for the writing to the .dot file.
        /// 
        /// Writes the expression into the .dot file as a tree in the corresponding
        /// format (the .dot file requires).
        /// </summary>
        private void CreateDotFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                // General fluff to be inserted into the document.
                if (sw != null)
                {
                    sw.WriteLine("graph calculus {");
                    sw.WriteLine("\tnode [ fontname = \"Arial\" ]");
                    // Make a call to the recursive method that returns the entirity
                    // of the content that makes up the .dot file.
                    sw.Write(expressionParser.DotFileGraph());
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
    }
}

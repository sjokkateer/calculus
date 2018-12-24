using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace eXpressionParsing
{
    class Chart
    {
        private List<double> mostRecentXvalues;
        private List<double> mostRecentYValues;

        public Axis X;
        public Axis Y;

        public Chart() : this(-10, -10, 1, -10, 10, 2)
        { }

        public Chart(double xMin, double xMax, int xAxisInterval, double yMin, double yMax, int yAxisInterval)
        {
            X = new Axis(xMin, xMax, xAxisInterval);
            Y = new Axis(yMin, yMax, yAxisInterval);
        }
    }
}

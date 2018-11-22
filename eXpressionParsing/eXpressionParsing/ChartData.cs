using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class ChartData
    {
        private double xMin;
        private double xMax;
        private double yMin;
        private double yMax;
        private double step;

        public ChartData()
        { }

        public ChartData(double xMin = -5, double xMax = 5, double yMin = -10, double yMax = 15, double step = 0.0001)
        {
            this.xMin = xMin;
            this.xMax = xMax;

            this.yMin = yMin;
            this.yMax = yMax;

            this.step = step;


        }
    }
}

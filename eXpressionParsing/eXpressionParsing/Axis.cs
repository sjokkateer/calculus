using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Axis
    {
        // Properties
        public double Min { get; set; }
        public double Max { get; set; }
        public int Interval { get; set; }

        // Constructors
        public Axis()
        { }

        public Axis(double min, double max, int interval)
        {
            Min = min;
            Max = max;
            Interval = interval;
        }
    }
}

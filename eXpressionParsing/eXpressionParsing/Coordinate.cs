using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Coordinate
    {
        public double X { get; }
        public double Y { get; }

        public Coordinate() : this(0.0, 0.0)
        { }

        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"({Math.Round(X, 2)}, {Math.Round(Y, 2)})";
        }
    }
}

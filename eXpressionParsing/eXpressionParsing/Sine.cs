using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Sine : UnaryOperator
    {
        public Sine() : base("sin")
        { }

        public override double Calculate(double x)
        {
            return Math.Sin(LeftSuccessor.Calculate(x));
        }
    }
}

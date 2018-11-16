using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Exp : UnaryOperator
    {
        public Exp() : base("e^")
        { }

        public override double Calculate(double x)
        {
            return Math.Exp(LeftSuccessor.Calculate(x));
        }
    }
}

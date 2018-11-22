using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class NaturalLog : UnaryOperator
    {
        public NaturalLog() : base("ln")
        { }

        public override double Calculate(double x)
        {
            return Math.Log(LeftSuccessor.Calculate(x));
        }

        public override Operand Differentiate()
        {
            // ln(x) = 1 / x
            // ln(a) = 0
            // ln(s(x)) = (1 / s(x) ) * c(x)
            throw new NotImplementedException("The derivative of ln(x) is not implemented yet.");
        }
    }
}

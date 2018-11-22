using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Power : BinaryOperator
    {
        public Power() : base('^')
        { }

        public override double Calculate(double x)
        {
            return Math.Pow(LeftSuccessor.Calculate(x), RightSuccessor.Calculate(x));
        }

        public override Operand Differentiate()
        {
            throw new NotImplementedException();
        }
    }
}

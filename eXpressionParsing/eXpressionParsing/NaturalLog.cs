using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class NaturalLog : UnaryOperator
    {
        public NaturalLog() : base('l')
        { }

        public override double Calculate(double x)
        {
            return Math.Log(LeftSuccessor.Calculate(x));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Division : BinaryOperator
    {
        public Division() : base('/')
        { }

        public override double Calculate(double x)
        {
            return LeftSuccessor.Calculate(x) / RightSuccessor.Calculate(x);
        }
    }
}

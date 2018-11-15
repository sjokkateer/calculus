using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class DependentVariableX : Operand
    {
        public DependentVariableX() : base('x')
        { }

        public override double Calculate(double x)
        {
            return x;
        }
    }
}

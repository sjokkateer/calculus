using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Number : Operand
    {
        public Number(double data) : base(data)
        { }

        public override double Calculate(double x)
        {
            return (double)Data;
        }
    }
}

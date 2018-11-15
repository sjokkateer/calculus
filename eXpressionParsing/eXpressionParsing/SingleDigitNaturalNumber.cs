using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class SingleDigitNaturalNumber : Operand
    {
        public SingleDigitNaturalNumber(char data) : base(data)
        { }

        public override double Calculate(double x)
        {
            return ((char)Data) - 48;
        }
    }
}

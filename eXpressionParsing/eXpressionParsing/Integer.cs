using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Integer : Operand
    {
        public Integer(int data) : base(data)
        { }

        public override double Calculate(double x)
        {
            return (int)Data;
        }
    }
}

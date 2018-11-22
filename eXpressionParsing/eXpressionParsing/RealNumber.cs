using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class RealNumber : Operand
    {
        public RealNumber(object data) : base(data)
        { }

        public override double Calculate(double x)
        {
            return (double)Data;
        }

        public override Operand Differentiate()
        {
            return new RealNumber(0.0);
        }
    }
}

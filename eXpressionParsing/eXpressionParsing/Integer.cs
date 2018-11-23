using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Integer : Operand
    {
        public Integer(object data) : base(data)
        { }

        public override Operand Copy()
        {
            return new Integer(Data);
        }

        public override double Calculate(double x)
        {
            return Convert.ToDouble(Data);
        }

        public override Operand Differentiate()
        {
            return new Integer(0.0);
        }
    }
}

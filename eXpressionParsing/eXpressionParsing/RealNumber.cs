using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class RealNumber : Integer
    {
        public RealNumber(object data) : base(data)
        { }

        public override Operand Copy()
        {
            return new RealNumber(Data);
        }

        public override double Calculate(double x)
        {
            return Convert.ToDouble(Data);
        }

        public override Operand Differentiate()
        {
            return new RealNumber(0.0);
        }

        //public override string ToString()
        //{
        //    return $"{Math.Round(Convert.ToDouble(Data), 2)}";
        //}

        //public override string NodeLabel()
        //{
        //    return $"\tnode{NodeNumber} [ label = \"{Math.Round(Convert.ToDouble(Data), 2)}\" ]\n";
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Cosine : UnaryOperator
    {
        public Cosine() : base('c')
        { }

        public override double Calculate(double x)
        {
            return Math.Cos(LeftSuccessor.Calculate(x));
        }

        public override string NodeLabel()
        {
            return $"[ label = \"{Data}os\" ]\n"; ;
        }
    }
}

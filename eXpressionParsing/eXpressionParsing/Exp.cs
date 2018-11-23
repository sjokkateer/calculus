using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Exp : UnaryOperator
    {
        public Exp() : base("e^")
        { }
        public override Operand Copy()
        {
            Exp copy = new Exp();
            copy.LeftSuccessor = LeftSuccessor.Copy();
            return copy;
        }
        public override double Calculate(double x)
        {
            return Math.Exp(LeftSuccessor.Calculate(x));
        }

        public override Operand Differentiate()
        {
            // (e^u)' = e^u * u'
            // e^u
            Exp outerFunction = (Exp)Copy();
            
            // u'
            Operand innerDerivative = LeftSuccessor.Differentiate();
            
            // e^u * u'
            Multiplication derivative = new Multiplication();
            derivative.LeftSuccessor = outerFunction;
            derivative.RightSuccessor = innerDerivative;

            return derivative;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Sine : UnaryOperator
    {
        public Sine() : base("sin")
        { }

        public override Operand Copy()
        {
            Sine copy = new Sine();
            copy.LeftSuccessor = LeftSuccessor.Copy();
            return copy;
        }

        public override double Calculate(double x)
        {
            return Math.Sin(LeftSuccessor.Calculate(x));
        }

        public override Operand Differentiate()
        {
            // Derivative of sin(u) = cos(u) * u'
            // c(u)
            Cosine outerDerivative = new Cosine();
            outerDerivative.LeftSuccessor = LeftSuccessor.Copy();

            // Now for u' we call it's differentiate method.
            Operand innerDerivative = LeftSuccessor.Differentiate();

            // c(u) * u'
            Multiplication derivative = new Multiplication();
            derivative.LeftSuccessor = outerDerivative;
            derivative.RightSuccessor = innerDerivative;

            return derivative;
        }
    }
}

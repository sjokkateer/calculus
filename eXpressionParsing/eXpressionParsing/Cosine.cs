using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Cosine : UnaryOperator
    {
        public Cosine() : base("cos")
        { }

        public override double Calculate(double x)
        {
            return Math.Cos(LeftSuccessor.Calculate(x));
        }
        public override Operand Copy()
        {
            Cosine copy = new Cosine();
            copy.LeftSuccessor = LeftSuccessor.Copy();
            return copy;
        }

        public override Operand Differentiate()
        {
            // Apply the chain rule.
            // Derivative of cos(u) = -sin(u) * u'
            Integer leftOuterDerivativeExpression = new Integer(-1);
            Sine rightOuterDerivativeExpression = new Sine();
            // s(u)
            rightOuterDerivativeExpression.LeftSuccessor = LeftSuccessor.Copy();
            // -1 * sin(u)
            Multiplication outerDerivative = new Multiplication();
            outerDerivative.LeftSuccessor = leftOuterDerivativeExpression;
            outerDerivative.RightSuccessor = rightOuterDerivativeExpression;

            // Now for u' we call it's differentiate method.
            Operand innerDerivative = LeftSuccessor.Differentiate();

            Multiplication derivative = new Multiplication();
            derivative.LeftSuccessor = outerDerivative;
            derivative.RightSuccessor = innerDerivative;
            return derivative;
        }
    }
}

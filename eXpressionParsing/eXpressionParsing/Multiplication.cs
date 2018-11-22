using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Multiplication : BinaryOperator
    {
        public Multiplication() : base('*')
        { }

        public override double Calculate(double x)
        {
            return LeftSuccessor.Calculate(x) * RightSuccessor.Calculate(x);
        }

        public override Operand Differentiate()
        {
            // The product rule:
            // (g * h)' = g * h' + g' * h
            Operand leftExpression = LeftSuccessor;
            Operand rightDerivative = RightSuccessor.Differentiate();

            Multiplication newLeftExpression = new Multiplication();
            newLeftExpression.LeftSuccessor = leftExpression;
            newLeftExpression.RightSuccessor = rightDerivative;

            Operand leftDerivative = LeftSuccessor.Differentiate();
            Operand rightExpression = RightSuccessor;

            Multiplication newRightExpression = new Multiplication();
            newRightExpression.LeftSuccessor = leftDerivative;
            newRightExpression.RightSuccessor = rightExpression;

            Addition derivative = new Addition();
            derivative.LeftSuccessor = newLeftExpression;
            derivative.RightSuccessor = newRightExpression;

            return derivative;
        }
    }
}

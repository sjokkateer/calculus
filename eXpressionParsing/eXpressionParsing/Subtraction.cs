using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Subtraction : BinaryOperator
    {
        public Subtraction() : base('-')
        { }

        public override Operand Simplify()
        {
            Subtraction simplifiedExpression = new Subtraction();
            simplifiedExpression.LeftSuccessor = LeftSuccessor.Simplify();
            simplifiedExpression.RightSuccessor = RightSuccessor.Simplify();
            if (simplifiedExpression.LeftSuccessor is Integer && !(simplifiedExpression.LeftSuccessor is PI)) // Left is not PI and a number.
            {
                // In this scenario the right sub tree can be an expression still.
                if (simplifiedExpression.RightSuccessor is Integer && !(simplifiedExpression.RightSuccessor is PI)) // Right not PI and a number.
                {
                    // We have 2 numbers so we can safely calculate.
                    double difference = Convert.ToDouble(simplifiedExpression.LeftSuccessor.Data) - Convert.ToDouble(simplifiedExpression.RightSuccessor.Data);
                    return new RealNumber(difference);
                }
                // Left can be 0 and that means the right is negative and we leave the expression tree as 0 - right expression
                // to not have to worry about unary or binary operator of subtraction.
            }
            else if (simplifiedExpression.RightSuccessor is Integer && !(simplifiedExpression.RightSuccessor is PI)) // Left was either an expression or it is PI.
            { // Thus we have to ensure that the Right is not PI or crash.
                // This case means that left is not a number. And we thus should be
                // able to return the negative of the right expression.
                if (Convert.ToDouble(simplifiedExpression.RightSuccessor.Data) == 0.0)
                {
                    return simplifiedExpression.LeftSuccessor.Simplify();
                }
            }
            return simplifiedExpression;
        }

        public override Operand Copy()
        {
            Subtraction copy = new Subtraction();
            copy.LeftSuccessor = LeftSuccessor.Copy();
            copy.RightSuccessor = RightSuccessor.Copy();
            return copy;
        }

        public override double Calculate(double x)
        {
            return LeftSuccessor.Calculate(x) - RightSuccessor.Calculate(x);
        }

        /// <summary>
        /// (f - g)' = f'- g'
        /// Meaning we differentiate both the left and right sub tree first
        /// and return a subtraction operator with the differentiated sub trees
        /// as it's successors
        /// </summary>
        /// <returns>
        /// A subtraction operator object with both left 
        /// and right successor differentiated.
        /// </returns>
        public override Operand Differentiate()
        {
            Operand leftDerivative = LeftSuccessor.Differentiate();
            Operand rightDerivative = RightSuccessor.Differentiate();

            Subtraction derivative = new Subtraction();
            derivative.LeftSuccessor = leftDerivative;
            derivative.RightSuccessor = rightDerivative;

            return derivative;
        }
    }
}

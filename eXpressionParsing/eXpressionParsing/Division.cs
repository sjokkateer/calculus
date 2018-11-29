using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Division : BinaryOperator
    {
        private Operand denominator;
        public override Operand RightSuccessor
        {
            get { return denominator; }
            set
            {
                if (value is Integer && !(value is PI))
                {
                    if (Convert.ToDouble(value.Data) == 0.0)
                    {
                        throw new DivideByZeroException("Can not divide by zero.");
                    }
                    else
                    {
                        denominator = value;
                    }
                }
                else
                {
                    denominator = value;
                }
            }
        }
        public Division() : base('/')
        { }

        public override Operand Simplify()
        {
            // Try to simplify as much as possible.
            Division simplifiedExpression = new Division();
            simplifiedExpression.LeftSuccessor = LeftSuccessor.Simplify();
            simplifiedExpression.RightSuccessor = RightSuccessor.Simplify();
            // When we divide by 1, we can just return
            // the numerator of the division.
            if (simplifiedExpression.RightSuccessor is Integer && !(simplifiedExpression.RightSuccessor is PI)) // If a number but not PI.
            {
                // The denominator = 1, thus we can return the numerator.
                if (Convert.ToDouble(simplifiedExpression.RightSuccessor.Data) == 1) // If the number is 1, we simplify it to just the simplification of the left branch.
                {
                    return simplifiedExpression.LeftSuccessor.Simplify();
                }
            }
            else if (simplifiedExpression.LeftSuccessor is Integer && !(simplifiedExpression.LeftSuccessor is PI)) // The right was either not a number or PI.
            { // We ensured that the left is not PI

                // Check if the numerator is 0
                // if so we can return a number 0.
                if (Convert.ToDouble(simplifiedExpression.LeftSuccessor.Data) == 0.0)
                {
                    return new RealNumber(0.0);
                }
            }
            return simplifiedExpression;
        }

        public override Operand Copy()
        {
            Division copy = new Division();
            copy.LeftSuccessor = LeftSuccessor.Copy();
            copy.RightSuccessor = RightSuccessor.Copy();
            return copy;
        }

        public override double Calculate(double x)
        {
            return LeftSuccessor.Calculate(x) / RightSuccessor.Calculate(x);
        }

        /// <summary>
        /// The quotient rule
        /// 
        /// (f / g)' = (gf' - g'f) / g^2
        /// 
        /// </summary>
        /// <returns>A division operator object holding respective expressions.</returns>
        public override Operand Differentiate()
        {
            // Create gf'
            Multiplication leftNumerator = new Multiplication();
            leftNumerator.LeftSuccessor = RightSuccessor.Copy();
            leftNumerator.RightSuccessor = LeftSuccessor.Differentiate();

            // Create g'f
            Multiplication rightNumerator = new Multiplication();
            rightNumerator.LeftSuccessor = RightSuccessor.Differentiate();
            rightNumerator.RightSuccessor = LeftSuccessor.Copy();

            // Create the numrator of previous terms gf' - g'f
            Subtraction derivativeNumerator = new Subtraction();
            derivativeNumerator.LeftSuccessor = leftNumerator;
            derivativeNumerator.RightSuccessor = rightNumerator;

            // Create g^2 of a new copy of g.
            Power derivativeDenominator = new Power();
            derivativeDenominator.LeftSuccessor = RightSuccessor.Copy();
            derivativeDenominator.RightSuccessor = new Integer(2);

            // Create the final result and assign. (f / g)' = (gf' - g'f) / g^2
            Division derivative = new Division();
            derivative.LeftSuccessor = derivativeNumerator;
            derivative.RightSuccessor = derivativeDenominator;

            return derivative;
        }
    }
}

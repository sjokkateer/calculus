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
        public override Operand Copy()
        {
            Multiplication copy = new Multiplication();
            copy.LeftSuccessor = LeftSuccessor.Copy();
            copy.RightSuccessor = RightSuccessor.Copy();
            return copy;
        }
        public override double Calculate(double x)
        {
            return LeftSuccessor.Calculate(x) * RightSuccessor.Calculate(x);
        }
        public override Operand Simplify()
        {
            Multiplication simplifiedExpression = (Multiplication)Copy();
            simplifiedExpression.LeftSuccessor = LeftSuccessor.Simplify();
            simplifiedExpression.RightSuccessor = RightSuccessor.Simplify();
            // If either of the operands equals 0 or 1 then we want to simplify specifically.
            if (simplifiedExpression.RightSuccessor is Integer && !(simplifiedExpression.RightSuccessor is PI)) // Right is a number but not PI.
            {
                // If Left is also an integer we can create a new real number operand for the result and return it up.
                if (simplifiedExpression.LeftSuccessor is Integer && !(simplifiedExpression.LeftSuccessor is PI)) // As long as the left is not PI or crash.
                {
                    double result = Convert.ToDouble(simplifiedExpression.RightSuccessor.Data) * Convert.ToDouble(simplifiedExpression.LeftSuccessor.Data);
                    return new RealNumber(result);
                }

                // If both are numbers we could multiply and return the result.
                // But this might be iffy with double values and rounding errors?
                switch (Convert.ToDouble(simplifiedExpression.RightSuccessor.Data)) // Safe as Right is not PI in this case.
                {
                    case 0.0: // Multiply by zero means return 0.
                        return new Integer(0.0);
                    case 1.0: // Multiply by one means return the other part of the expression.
                        return simplifiedExpression.LeftSuccessor.Simplify();
                }
            }
            else if (simplifiedExpression.LeftSuccessor is Integer && !(simplifiedExpression.LeftSuccessor is PI)) // This means the simplified right expression was not a number.
            { // Since the Right is not a number or it was PI.
                switch (Convert.ToDouble(simplifiedExpression.LeftSuccessor.Data)) // The left is not PI so we can convert the data to a number
                {
                    case 0.0:
                        return new Integer(0.0);
                    case 1.0:
                        return simplifiedExpression.RightSuccessor.Simplify();
                }
            }
            return simplifiedExpression;
        }
        /// <summary>
        /// Applies the product rule to the sub trees.
        /// (f * g)' = f * g' + f' * g
        /// 
        /// The method differentiates the appropriate sub trees and 
        /// eventually returns a single Operand object (in this case
        /// an addition operator object) holding both an original 
        /// expression sub tree as well as a differentiated sub tree.
        /// </summary>
        /// <returns>
        /// An operator object, representing the applied product rule.
        /// </returns>
        public override Operand Differentiate()
        {
            // Create and assign fg'
            Multiplication newLeftExpression = new Multiplication();
            newLeftExpression.LeftSuccessor = LeftSuccessor.Copy();
            newLeftExpression.RightSuccessor = RightSuccessor.Differentiate();

            // Create and assign f'g
            Multiplication newRightExpression = new Multiplication();
            newRightExpression.LeftSuccessor = LeftSuccessor.Differentiate();
            newRightExpression.RightSuccessor = RightSuccessor.Copy();

            // Create and assign fg' + f'g
            Addition derivative = new Addition();
            derivative.LeftSuccessor = newLeftExpression;
            derivative.RightSuccessor = newRightExpression;

            return derivative;
        }
    }
}

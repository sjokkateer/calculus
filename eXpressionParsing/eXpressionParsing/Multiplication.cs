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
            Operand leftExpression = LeftSuccessor;
            Operand rightDerivative = RightSuccessor.Differentiate();

            // fg'
            Multiplication newLeftExpression = new Multiplication();
            newLeftExpression.LeftSuccessor = leftExpression;
            newLeftExpression.RightSuccessor = rightDerivative;

            Operand leftDerivative = LeftSuccessor.Differentiate();
            Operand rightExpression = RightSuccessor;

            // f'g
            Multiplication newRightExpression = new Multiplication();
            newRightExpression.LeftSuccessor = leftDerivative;
            newRightExpression.RightSuccessor = rightExpression;

            // fg' + f'g
            Addition derivative = new Addition();
            derivative.LeftSuccessor = newLeftExpression;
            derivative.RightSuccessor = newRightExpression;

            return derivative;
        }
    }
}

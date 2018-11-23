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

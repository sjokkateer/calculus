using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class Addition : BinaryOperator
    {
        public Addition() : base('+')
        { }

        public override double Calculate(double x)
        {
            return LeftSuccessor.Calculate(x) + RightSuccessor.Calculate(x);
        }

        /// <summary>
        /// (f + g)' = f' + g'
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
            // (f + g)' = f' + g'
            Operand leftDerivative = LeftSuccessor.Differentiate();
            Operand rightDerivative = RightSuccessor.Differentiate();

            Addition derivative = new Addition();
            derivative.LeftSuccessor = leftDerivative;
            derivative.RightSuccessor = rightDerivative;

            return derivative;
        }
    }
}

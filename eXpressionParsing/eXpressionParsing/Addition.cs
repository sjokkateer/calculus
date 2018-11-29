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

        public override Operand Copy()
        {
            Addition copy = new Addition();
            copy.LeftSuccessor = LeftSuccessor.Copy();
            copy.RightSuccessor = RightSuccessor.Copy();
            return copy;
        }

        public override Operand Simplify()
        {
            Addition simplifiedExpression = new Addition();
            simplifiedExpression.LeftSuccessor = LeftSuccessor.Simplify();
            simplifiedExpression.RightSuccessor = RightSuccessor.Simplify();
            if (simplifiedExpression.LeftSuccessor is Integer && !(simplifiedExpression.LeftSuccessor is PI)) // Must not be PI or crash.
            {
                // If the right is also a number, we can simplify the two by calculating the result.
                // and return a new operand object holding the result as data up to the previous call.
                if (simplifiedExpression.RightSuccessor is Integer && !(simplifiedExpression.RightSuccessor is PI)) // Must not be PI or crash, or loss of info if we simplify perhaps.
                {
                    // These will always be non PI numbers either int or real.
                    double addition = Convert.ToDouble(simplifiedExpression.LeftSuccessor.Data) + Convert.ToDouble(simplifiedExpression.RightSuccessor.Data);
                    return new RealNumber(addition);
                }
                else if (Convert.ToDouble(simplifiedExpression.LeftSuccessor.Data) == 0.0) // This left is never PI, if it is 0 we can simplify right safely.
                {
                    return simplifiedExpression.RightSuccessor.Simplify();
                }
            }
            else if (simplifiedExpression.RightSuccessor is Integer && !(simplifiedExpression.RightSuccessor is PI)) // Right must not be PI or it'll crash.
            {
                if (Convert.ToDouble(simplifiedExpression.RightSuccessor.Data) == 0)
                {
                    return simplifiedExpression.LeftSuccessor.Simplify();
                }
            }
            return simplifiedExpression;
        }

        public override double Calculate(double x)
        {
            return LeftSuccessor.Calculate(x) + RightSuccessor.Calculate(x);
        }

        /// <summary>
        /// (f + g)' = f' + g'
        /// Meaning we differentiate both the left and right sub tree first
        /// and return an addition operator with the differentiated sub trees
        /// as it's successors
        /// </summary>
        /// <returns>
        /// An addition operator object with both left 
        /// and right successor differentiated.
        /// </returns>
        public override Operand Differentiate()
        {
            Addition derivative = new Addition();
            derivative.LeftSuccessor = LeftSuccessor.Differentiate();
            derivative.RightSuccessor = RightSuccessor.Differentiate();

            return derivative;
        }
    }
}

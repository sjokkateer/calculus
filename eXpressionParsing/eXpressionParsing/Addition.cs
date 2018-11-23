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

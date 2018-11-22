using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class NaturalLog : UnaryOperator
    {
        public NaturalLog() : base("ln")
        { }

        public override double Calculate(double x)
        {
            return Math.Log(LeftSuccessor.Calculate(x));
        }

        public override Operand Differentiate()
        {
            // (ln(u))' = 1 / u * u'
            Division leftExpression = new Division();
            leftExpression.LeftSuccessor = new Integer(1);
            // 1 / u
            leftExpression.RightSuccessor = LeftSuccessor;
            // u'
            Operand rightExpression = LeftSuccessor.Differentiate();

            // 1 / u * u'
            Multiplication derivative = new Multiplication();
            derivative.LeftSuccessor = leftExpression;
            derivative.RightSuccessor = rightExpression;
            return derivative;
        }
    }
}

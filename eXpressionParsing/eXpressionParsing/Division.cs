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
                if (value is Integer)
                {
                    if ((int)value.Data == 0)
                    {
                        throw new DivideByZeroException("Can not divide by zero.");
                    }
                    else
                    {
                        denominator = value;
                    }
                }
                else if (value is RealNumber)
                {
                    if ((double)value.Data == 0.0)
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
            // Do we need to take into account xes, functions and constants
            // when differentiating.
            Operand denominator = RightSuccessor.Copy();
            Operand differentiatedNumerator = LeftSuccessor.Differentiate();

            // gf'
            Multiplication leftNumerator = new Multiplication();
            leftNumerator.LeftSuccessor = denominator;
            leftNumerator.RightSuccessor = differentiatedNumerator;

            Operand numerator = LeftSuccessor.Copy();
            Operand differentiatedDenominator = RightSuccessor.Differentiate();

            // g'f
            Multiplication rightNumerator = new Multiplication();
            rightNumerator.LeftSuccessor = differentiatedDenominator;
            rightNumerator.RightSuccessor = numerator;

            // gf' - g'f
            Subtraction derivativeNumerator = new Subtraction();
            derivativeNumerator.LeftSuccessor = leftNumerator;
            derivativeNumerator.RightSuccessor = rightNumerator;

            // g^2
            Power derivativeDenominator = new Power();
            derivativeDenominator.LeftSuccessor = denominator;
            derivativeDenominator.RightSuccessor = new Integer(2);

            // (f / g)' = (gf' - g'f) / g^2
            Division derivative = new Division();
            derivative.LeftSuccessor = derivativeNumerator;
            derivative.RightSuccessor = derivativeDenominator;

            return derivative;
        }
    }
}

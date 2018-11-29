using System;

namespace eXpressionParsing
{
    class Power : BinaryOperator
    {
        public Power() : base('^')
        { }

        public override double Calculate(double x)
        {
            return Math.Pow(LeftSuccessor.Calculate(x), RightSuccessor.Calculate(x));
        }

        public override Operand Simplify()
        {
            if (!(RightSuccessor is PI)) // Ensure the power is not PI or it would crash.
            {
                if (Convert.ToDouble(RightSuccessor.Data) == 1.0) // If it's 1 we return the simplified version of left.
                {
                    return LeftSuccessor.Simplify();
                }
                return Copy(); // Otherwise just the copy.
            }
            else // All other cases, just return the copy.
            {
                return Copy();
            }
        }

        public override Operand Copy()
        {
            Power copy = new Power();
            copy.LeftSuccessor = LeftSuccessor.Copy();
            copy.RightSuccessor = RightSuccessor.Copy();
            return copy;
        }

        public override Operand Differentiate()
        {
            // (f(x))^b where b is a natural number even.
            // The general power rule but combined with the
            // chain rule. b * (f(x))^(b - 1) * f'(x)
            
            // b
            Operand power = RightSuccessor.Copy();
            
            // b - 1
            Integer newPower = new Integer((double)power.Data - 1);
            
            // f(x)^(b - 1)
            Power onePowerLess = new Power();
            onePowerLess.LeftSuccessor = LeftSuccessor.Copy();
            onePowerLess.RightSuccessor = newPower;

            // f'
            Operand derivativeOfF = LeftSuccessor.Differentiate();

            // b * f(x)^(b - 1)
            Multiplication intermediaryResult = new Multiplication();
            intermediaryResult.LeftSuccessor = power;
            intermediaryResult.RightSuccessor = onePowerLess;

            // (b * f(x)^(b - 1)) * f'
            Multiplication derivative = new Multiplication();
            derivative.LeftSuccessor = intermediaryResult;
            derivative.RightSuccessor = derivativeOfF;

            return derivative;
        }
    }
}

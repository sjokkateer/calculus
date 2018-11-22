using System;

namespace eXpressionParsing
{
    class Power : BinaryOperator
    {
        private Operand exponent;

        public override Operand RightSuccessor
        {
            get { return exponent; }
            set
            {
                // Validate that the input is an Integer object or if it just got constructed and has value null.
                if (value is Integer || value == null)
                {
                    exponent = value;
                }
                else
                {
                    // Otherwise the input type according to the assignment is invalid.
                    throw new InvalidArgumentTypeException("A power function requires the power to be of type integer.");
                }
            }
        }
        public Power() : base('^')
        { }

        public override double Calculate(double x)
        {
            return Math.Pow(LeftSuccessor.Calculate(x), RightSuccessor.Calculate(x));
        }

        public override Operand Differentiate()
        {
            // (f(x))^b where b is a natural number even.
            // The general power rule but combined with the
            // chain rule. b * (f(x))^(b - 1) * f'(x)
            
            // b
            Operand power = RightSuccessor;
            
            // b - 1
            Integer newPower = new Integer((int)power.Data - 1);
            
            // f(x)^(b - 1)
            Power onePowerLess = new Power();
            onePowerLess.LeftSuccessor = LeftSuccessor;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (value is Integer || value == null)
                {
                    exponent = value;
                }
                else
                {
                    throw new Exception("Please enter an integer power.");
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

using System;

namespace eXpressionParsing
{
    class PI : Operand
    {
        public PI() : base("pi")
        { }

        public override double Calculate(double x)
        {
            return Math.PI;
        }
    }
}

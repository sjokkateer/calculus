using System;

namespace eXpressionParsing
{
    class PI : RealNumber
    {
        public PI() : base("pi")
        { }

        public override Operand Copy()
        {
            return new PI();
        }

        public override double Calculate(double x)
        {
            return Math.PI;
        }
    }
}

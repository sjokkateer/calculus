using System;

namespace eXpressionParsing
{
    class PI : Operand
    {
        public PI() : base('p')
        { }

        public override double Calculate(double x)
        {
            return Math.PI;
        }

        public override string NodeLabel()
        {
            return $"[ label = \"{Data}i\" ]\n"; ;
        }
    }
}

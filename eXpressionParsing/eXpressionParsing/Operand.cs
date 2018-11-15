using System;

namespace eXpressionParsing
{
    abstract class Operand
    {
        public object Data { get; }

        public Operand(object data)
        {
            Data = data;
        }

        public abstract double Calculate(double x);

        public override string ToString()
        {
            return Convert.ToString(Data);
        }
    }
}

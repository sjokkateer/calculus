using System;

namespace eXpressionParsing
{
    abstract class Operand
    {
        // Skip node number and just do it in one iteration, print the label
        // for operands and print label + connections for operators.
        public int NodeNumber { get; set; }
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

        public string NodeLabel()
        {
            return $"node{NodeNumber} [ label = \"{Data}\" ]\n";
        }

        public virtual string Relation()
        {
            return "";
        }
    }
}

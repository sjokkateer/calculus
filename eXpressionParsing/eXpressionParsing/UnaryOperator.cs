using System;

namespace eXpressionParsing
{
    abstract class UnaryOperator : Operand
    {
        public Operand LeftSuccessor { get; set; }

        public UnaryOperator(object data) : base(data)
        {
            LeftSuccessor = null;
        }

        public override string ToString()
        {
            string result = Convert.ToString(Data);
            if (!(LeftSuccessor is BinaryOperator))
            {
                result += "(";
                result += LeftSuccessor;
                result += ")";
            }
            else
            {
                result += LeftSuccessor;
            }
            return result;
        }

        public override string NodeLabel()
        {
            string result = base.NodeLabel();
            result += $"node{NodeNumber} -- node{LeftSuccessor.NodeNumber}\n";
            result += LeftSuccessor.NodeLabel();
            return result;
        }
    }
}

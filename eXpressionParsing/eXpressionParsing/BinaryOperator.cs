namespace eXpressionParsing
{
    abstract class BinaryOperator : UnaryOperator
    {
        public Operand RightSuccessor { get; set; }

        public BinaryOperator(object data) : base(data)
        {
            RightSuccessor = null;
        }

        public override string ToString()
        {
            string result = "(";
            result += LeftSuccessor;
            result += $" {Data} ";
            result += RightSuccessor;
            result += ")";
            return result;
        }

        public override string NodeLabel()
        {
            string result = base.NodeLabel();
            result += $"\tnode{NodeNumber} -- node{RightSuccessor.NodeNumber}\n";
            result += RightSuccessor.NodeLabel();
            return result;
        }
    }
}

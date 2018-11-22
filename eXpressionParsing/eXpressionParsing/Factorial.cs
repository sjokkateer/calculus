namespace eXpressionParsing
{
    class Factorial : UnaryOperator
    {
        public Factorial() : base('!')
        { }

        public override double Calculate(double x)
        {
            return recFactorial((int)LeftSuccessor.Calculate(x));
        }

        public override string ToString()
        {
            string result = "";
            if (LeftSuccessor is UnaryOperator)
            {
                result += "(";
                result += LeftSuccessor;
                result += ")";
            }
            else
            {
                result += LeftSuccessor;
            }
            result += Data;
            return result;
        }

        private int recFactorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return n * recFactorial(n - 1);
            }
        }

        public override Operand Differentiate()
        {
            return new Integer(0);
        }
    }
}

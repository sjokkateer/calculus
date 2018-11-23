namespace eXpressionParsing
{
    class Factorial : UnaryOperator
    {
        private Operand naturalNumber;
        public override Operand LeftSuccessor
        {
            get { return naturalNumber; }
            set
            {
                // Validate that the input to factorial is an integer.
                if (value is Integer)
                {
                    // Validate the value being >= 0 to be valid.
                    if ((int)value.Data >= 0)
                    {
                        naturalNumber = value;
                    }
                    else
                    {
                        throw new InvalidFactorialArgumentException($"Factorial only takes values >= 0, not {value}.");
                    }
                }
                else if (value == null) // Allow null to be assigned upon construction of the operator.
                {
                    naturalNumber = value;
                }
                else // Otherwise some invalid operation happened and we return an error.
                {
                    throw new InvalidArgumentTypeException("Factorial needs a natural number as input type.");
                }
            }
        }
        public Factorial() : base('!')
        { }
        public override Operand Copy()
        {
            Factorial copy = new Factorial();
            copy.LeftSuccessor = LeftSuccessor.Copy();
            return copy;
        }
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

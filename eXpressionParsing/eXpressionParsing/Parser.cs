using System.Collections.Generic;
using System.Linq;

namespace eXpressionParsing
{
    class Parser
    {
        private Operand expressionRoot;

        private const string OPERATORS = "+-*/^sc!el";
        private const string OPERANDS = "1234567890xp";

        private string expression;

        private List<char> operators;
        private List<Operand> operands;

        public Parser(string expression)
        {
            this.expression = expression;

            operators = new List<char>();
            operands = new List<Operand>();
        }

        public void Parse()
        {
            // Parse the expression until
            // The expression is an emxpty string.
            ParseHelper(expression);

            // Create tree of the final node (the root).
            expressionRoot = operands[0];
        }

        private void ParseHelper(string s)
        {
            if (s != string.Empty)
            {
                if (OPERATORS.Contains(s[0]))
                {
                    operators.Add(s[0]);
                }
                else if (OPERANDS.Contains(s[0]))
                {
                    Operand operand;
                    if (s[0] == 'x')
                    {
                        operand = new DependentVariableX();
                    }
                    else if (s[0] == 'p')
                    {
                        operand = new PI();
                    }
                    else
                    {
                        operand = new SingleDigitNaturalNumber(s[0]);
                    }
                    operands.Add(operand);
                }
                else if (s[0] == '(')
                {
                    // This has no meaning as of yet, besides a bracket 
                    // being added on top of the stack of operators.
                    operators.Add('(');
                }
                else if (s[0] == ')')
                {
                    // Remove '('
                    operators.RemoveAt(operators.Count - 1);
                    // Obtain the operator before the '('
                    char currentOperator = operators[operators.Count - 1];
                    // Remove the operator before the '(' (currentOperator)
                    operators.RemoveAt(operators.Count - 1);

                    // Calculate new intermediary value.
                    // In this new situation we create a new subtree from ((left operand) operator [right operand (optional) depending on the operator). 
                    CreateNode(currentOperator);
                }
                // Call self again starting from next character.
                ParseHelper(s.Substring(1));
            }
        }

        private void CreateNode(char operat0r)
        {
            Operand result = null;
            switch (operat0r)
            {
                case '+':
                    result = new Addition();
                    break;
                case '-':
                    result = new Subtraction();
                    break;
                case '*':
                    result = new Multiplication();
                    break;
                case '/':
                    result = new Division();
                    break;
                case '^':
                    result = new Power();
                    break;
                // Now for operators that take one argument.
                case '!':
                    result = new Factorial();
                    break;
                case 'l':
                    result = new NaturalLog();
                    break;
                case 'e':
                    result = new Exp();
                    break;
                case 'c':
                    result = new Cosine();
                    break;
                case 's':
                    result = new Sine();
                    break;
            }
            if (result is BinaryOperator)
            {
                // Add the operands to the binary operator.
                ((BinaryOperator)result).LeftSuccessor = operands[operands.Count - 2];
                ((BinaryOperator)result).RightSuccessor = operands[operands.Count - 1];

                // Remove the operands from the stack.
                operands.RemoveAt(operands.Count - 1);
                operands.RemoveAt(operands.Count - 1);
            }
            else
            {
                // Same story, add operand to operator.
                ((UnaryOperator)result).LeftSuccessor = operands[operands.Count - 1];

                // Remove operand from stack.
                operands.RemoveAt(operands.Count - 1);
            }

            // Add the sub tree on top of the operands stack.
            operands.Add(result);
        }

        // Calculates the f(x) of the expression 
        // for the current value of x.
        public double CalculateForX(double x)
        {
            return expressionRoot.Calculate(x);
        }

        public override string ToString()
        {
            return expressionRoot.ToString();
        }
    }
}

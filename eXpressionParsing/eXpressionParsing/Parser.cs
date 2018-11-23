using System.Collections.Generic;
using System.Linq;
using System;

namespace eXpressionParsing
{
    class Parser
    {
        // Several string constants that will be used
        // to detect what kind of object needs to be made
        // , and what data to store in it while parsing.
        private const string OPERATORS = "+-*/^sc!el";
        private const string OPERANDS = "1234567890xp";
        private const string NUMBER_OPERATORS = "rn";

        // Holds the entered expression as its original form.
        private string expression;

        // Two lists that will be used as stacks to process the expression.
        private List<char> operators;
        private List<Operand> operands;

        public Parser(string expression)
        {
            this.expression = expression;

            operators = new List<char>();
            operands = new List<Operand>();
        }

        /// <summary>
        /// Will parse the entered expression (in pre-fix notation)
        /// into an expression tree.
        /// </summary>
        /// <returns>The root node of the expression tree.</returns>
        public Operand Parse()
        {
            // Parse the expression until
            // The expression is an empty string.
            ParseHelper(expression);

            // Create tree of the final node (the root of the expression).
            return operands[0];
        }

        private void ParseHelper(string s)
        {
            if (s != string.Empty)
            {
                // Convert the operator to an object, if it is a valid operator.
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
                        operand = new Integer((double)(s[0] - 48));
                    }
                    operands.Add(operand);
                }
                else if (NUMBER_OPERATORS.Contains(s[0]))
                {
                    char numberOperator = s[0];

                    Operand operand;
                    string result = "";
                    // Strip string from the number operator
                    // as well as the open parenthesis.
                    s = s.Substring(2);

                    char currentChar = s[0];
                    while (currentChar != ')')
                    {
                        // Append the digit to the string of characters.
                        result += currentChar;

                        // Move forward one character.
                        s = s.Substring(1);
                        currentChar = s[0];
                    }
                    // Try to parse the resulting string (represents a number) 
                    // to prevent errors and add it to the stack of operands.
                    if (numberOperator == 'n') 
                    {

                        double numericResult;
                        bool isIntParsed = double.TryParse(result, out numericResult);
                        if (!isIntParsed)
                        {
                            throw new InvalidNumberException($"Please enter a valid integer value.\nYou entered: {result}");
                        }
                        operand = new Integer(numericResult);
                    }
                    else
                    {
                        double numericResult;
                        bool isDoubleParsed = double.TryParse(result, out numericResult);
                        if (!isDoubleParsed)
                        {
                            throw new InvalidNumberException($"Please enter a valid real number.\nYou entered: {result}");
                        }
                        operand = new RealNumber(numericResult);
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

        // Method that will create an appropriate operator class
        // from the obtained character.
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
                // Same story, add operand to unary operator.
                ((UnaryOperator)result).LeftSuccessor = operands[operands.Count - 1];

                // Remove operand from stack.
                operands.RemoveAt(operands.Count - 1);
            }

            // Add the sub tree on top of the operands stack.
            operands.Add(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressions
{
    class Parser
    {
        private const string OPERATORS = "+*-/^";
        private const string NATURAL_NUMBERS = "0123456789pxe";
        private const string NUMBER_OPERATOR = "nr";

        private string expression;
        private int expressionIndex = -1;

        private List<Node> operators; // These are internal nodes and will be filled by expressions and operands.
        private List<Node> operands; // These will represent leaf nodes.

        public Tree ExpressionTree { get; private set; }

        public Parser(string expression)
        {
            this.expression = expression;
            operators = new List<Node>();
            operands = new List<Node>();

            Parse();
        }

        private void Parse()
        {
            // *(+(3,7),-(2,1))
            Node root = ParseHelper();
            ExpressionTree = new Tree(root);
        }

        private Node ParseHelper()
        {
            expressionIndex++;
            Node n = null;
            char currentSymbol = expression[expressionIndex];

            if (OPERATORS.Contains(currentSymbol))
            {
                n = new Node(currentSymbol);
                n.LeftSuccessor = ParseHelper();
                n.RightSuccessor = ParseHelper();
            }
            else if (NATURAL_NUMBERS.Contains(currentSymbol))
            {
                n = new Node(currentSymbol);
            }
            else if (NUMBER_OPERATOR.Contains(currentSymbol))
            {
                double number = getSequenceOfNumbers();
                n = new Node(number);
            }
            if (n != null)
            {
                return n;
            }
            return ParseHelper();
        }

        private double getSequenceOfNumbers()
        {
            // Work In Progress
        }
    }
}

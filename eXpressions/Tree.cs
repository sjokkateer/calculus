using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressions
{
    class Tree
    {
        private const string OPERATORS = "+*-/^";
        // Actually a binarry tree.
        // Internal nodes are operators and  
        // leaves (external nodes) are operands.
        public Node Root { get; }

        // String representation of the expression after traversal.
        private string expression;

        public Tree(Node root)
        {
            Root = root;
        }

        public string InorderTraversal()
        {
            expression = "";
            InOrderHelper(Root);

            return expression;
        }

        private void InOrderHelper(Node node)
        {
            if (node != null)
            {
                if (OPERATORS.Contains((char)node.Data))
                {
                    expression += "(";
                }
                // Inorder LNR (aka Left, Node, Right).
                // Go as deep as possible left, before adding
                // the data of the node to the expression.
                InOrderHelper(node.LeftSuccessor);
                expression += node.Data;
                InOrderHelper(node.RightSuccessor);

                if (OPERATORS.Contains((char)node.Data))
                {
                    expression += ")";
                }
            }
        }
    }
}

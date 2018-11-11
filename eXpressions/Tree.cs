using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressions
{
    class Tree
    {
        // Actually a binarry two tree data structure.
        // Internal nodes are operators and leaves 
        // (external nodes) are operands.
        private Node root;

        // String representation of the expression after traversal.
        private string expression;

        public Tree()
        {
            root = null;
        }

        public void InsertNode(string data)
        {
            if (root == null)
            {
                root = new Node(data);
            }
            else
            {
                root.Insert(data);
            }
        }

        public string InorderTraversal()
        {
            expression = "";
            InOrderHelper(root);

            return expression;
        }

        private void InOrderHelper(Node node)
        {
            if (node != null)
            {
                // Inorder LNR (aka Left, Node, Right).
                // Go as deep as possible left, before adding
                // the data of the node to the expression.
                InOrderHelper(node.LeftSuccessor);
                expression += node.Data;
                InOrderHelper(node.RightSuccessor);
            }
        }
    }
}

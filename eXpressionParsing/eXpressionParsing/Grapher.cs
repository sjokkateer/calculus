using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace eXpressionParsing
{
    static class Grapher
    {
        /// <summary>
        /// Function that wraps several steps into one, such as a call to number label
        /// the nodes for processing by GraphViz.
        /// </summary>
        /// <param name="expressionRoot"></param>
        /// <param name="fileName"></param>
        public static void CreateGraphOfFunction(Operand expressionRoot, string fileName)
        {

            NumberOperands(expressionRoot);
            CreateGraph(fileName, expressionRoot.NodeLabel());
        }

        /// <summary>
        /// Labels all the nodes in the expression
        /// in a BFS manner such that a graph can be
        /// made for it.
        /// </summary>
        /// <param name="expressionRoot">Is the root of the expression to be number labeled</param>
        private static void NumberOperands(Operand expressionRoot)
        {
            List<Operand> queue = new List<Operand>();

            Operand currentOperand = expressionRoot;

            // Add the root as the first item in the queue.
            queue.Add(currentOperand);

            // Label the root as the first node (node1) and add it to
            // the queue.
            int nodeCounter = 1;
            while (currentOperand != null)
            {
                // Process the first operand of the queue.
                currentOperand.NodeNumber = nodeCounter;

                // Check what type of operator/operand to add its children to the queue.
                if (currentOperand is BinaryOperator)
                {
                    queue.Add(((BinaryOperator)currentOperand).LeftSuccessor);
                    queue.Add(((BinaryOperator)currentOperand).RightSuccessor);
                }
                else if (currentOperand is UnaryOperator)
                {
                    queue.Add(((UnaryOperator)currentOperand).LeftSuccessor);
                }
                // Remove the recently processed operand from the queue and try to
                // Obtain the next if there is one.
                queue.RemoveAt(0);
                // Check if it was not a single operand as input expression.
                if (queue.Count > 0)
                {
                    currentOperand = queue[0];
                }
                else
                {
                    currentOperand = null;
                }
                nodeCounter++;
            }
        }

        /// <summary>
        /// Method responsible for creating the image via the
        /// graphViz program, that is based on the input of
        /// a .dot file.
        /// </summary>
        /// <param name="dotFileName">A string, someFileName.dot
        /// that is used to create a .dot file that represents
        /// the expression in graph form.</param>
        private static void CreateGraph(string dotFileName, string fileContent)
        {
            CreateDotFile(dotFileName, fileContent);

            // Maybe move this code into a new method that can be re-used later.
            Process dot = new Process();
            dot.StartInfo.FileName = "dot.exe";
            dot.StartInfo.Arguments = $"-Tpng -o{dotFileName}.png {dotFileName}.dot";
            dot.Start();
            dot.WaitForExit();
        }

        /// <summary>
        /// Method dedicated to the actual creation of the dot file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileContent"></param>
        private static void CreateDotFile(string fileName, string fileContent)
        {
            FileStream fs = new FileStream($"{fileName}.dot", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                if (sw != null)
                {
                    sw.WriteLine("graph calculus {");
                    sw.WriteLine("\tnode [ fontname = \"Arial\" ]");
                    sw.Write(fileContent);
                    sw.WriteLine("}");
                    sw.Close();
                }
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }
    }
}

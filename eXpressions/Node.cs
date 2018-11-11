using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressions
{
    class Node
    {
        public Node LeftSuccessor { get; set; }
        public string Data { get; set; }
        public Node RightSuccessor { get; set; }

        public Node(string data)
        {
            Data = data;
            LeftSuccessor = RightSuccessor = null;
        }

        public void Insert(string insertData)
        {
            // If either the left or right node are available (null)
            // insert our data in either position, otherwise recursively
            // go down the left chain until we find a place to insert
            // our data.
            if (LeftSuccessor == null)
            {
                LeftSuccessor = new Node(insertData);
            }
            else if (RightSuccessor == null)
            {
                RightSuccessor = new Node(insertData);
            }
            else
            {
                LeftSuccessor.Insert(insertData);
            }
        }
    }
}

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
        public object Data { get; }
        public Node RightSuccessor { get; set; }

        public Node(object data)
        {
            Data = data;
            LeftSuccessor = RightSuccessor = null;
        }
    }
}

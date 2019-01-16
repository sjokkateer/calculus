using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions
{
    class InvalidLambdaException : Exception
    {
        public InvalidLambdaException()
        { }

        public InvalidLambdaException(string message) : base(message)
        { }

        public InvalidLambdaException(string message, Exception inner) : base(message, inner)
        { }
    }
}

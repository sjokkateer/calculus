using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions
{
    class InvalidNumberOfTrialsException : Exception
    {
        public InvalidNumberOfTrialsException()
        { }

        public InvalidNumberOfTrialsException(string message) : base(message)
        { }

        public InvalidNumberOfTrialsException(string message, Exception inner) : base(message, inner)
        { }
    }
}

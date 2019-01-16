using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions
{
    class InvalidInterArrivalValueException : Exception
    {
        public InvalidInterArrivalValueException()
        { }

        public InvalidInterArrivalValueException(string message) : base(message)
        { }

        public InvalidInterArrivalValueException(string message, Exception inner) : base(message, inner)
        { }
    }
}

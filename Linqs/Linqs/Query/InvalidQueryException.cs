using System;
using System.Collections.Generic;
using System.Text;

namespace Linqs.Query
{
    public class InvalidQueryException: Exception
    {
        public InvalidQueryException()
        {
        }

        public InvalidQueryException(string message)
            : base(message)
        {
        }

        public InvalidQueryException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

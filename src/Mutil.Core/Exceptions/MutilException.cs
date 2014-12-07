using System;

namespace Mutil.Core.Exceptions
{
    public class MutilException : Exception
    {
        public MutilException() : base()
        {

        }

        public MutilException(string message) : base(message)
        {

        }

        public MutilException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

using System;

namespace Mutil.Core.Exceptions
{
    public class AlreadyRegisteredException : MutilException
    {
        public Type RegisteredType { get; private set; }

        public AlreadyRegisteredException()
        {

        }

        public AlreadyRegisteredException(Type registeredType)
        {
            this.RegisteredType = registeredType;
        }

        public AlreadyRegisteredException(Type registeredType, string message) : base(message)
        {
            this.RegisteredType = registeredType;
        }

        public AlreadyRegisteredException(Type registeredType, string message, Exception inner) : base(message, inner)
        {
            this.RegisteredType = registeredType;
        }
    }
}

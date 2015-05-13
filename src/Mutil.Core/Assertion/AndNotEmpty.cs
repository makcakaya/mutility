using System;

namespace Mutil.Core.Assertion
{
    public sealed class AndNotEmpty : IAndNotEmpty
    {
        public IAndNotEmpty And(string argument, string argumentName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentException(string.Format("{0} cannot be empty.", argumentName));
            }

            return this;
        }
    }
}

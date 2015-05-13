using System;

namespace Mutil.Core.Assertion
{
    public sealed class AndNotWhiteSpace : IAndNotWhiteSpace
    {
        public IAndNotWhiteSpace And(string argument, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentException(string.Format("{0} cannot be white space.", argumentName));
            }

            return this;
        }
    }
}

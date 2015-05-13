using System;

namespace Mutil.Core.Assertion
{
    public sealed class AndThat : IAndThat
    {
        private bool _assertion = true;

        public AndThat(bool value)
        {
            _assertion = value;
        }

        public IAndThat And(bool value)
        {
            _assertion &= value;
            return this;
        }

        public void OrThrow(string message)
        {
            if (!_assertion)
            {
                throw new InvalidOperationException(message);
            }
        }

        public void OrThrow(Exception exception)
        {
            if (!_assertion)
            {
                throw exception;
            }
        }
    }
}

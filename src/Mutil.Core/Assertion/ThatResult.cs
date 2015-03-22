using Mutil.Core.DataTypes;
using System;

namespace Mutil.Core.Assertion
{
    public sealed class ThatResult
    {
        #region State

        private WriteOnce<bool> _predicate = new WriteOnce<bool>();

        #endregion State

        #region Ctor

        public ThatResult(bool value)
        {
            _predicate.Value = value;
        }

        #endregion Ctor

        #region Methods

        public void OrThrow<T>(T exception) where T : Exception
        {
            if (_predicate.Value) { return; }
            
            AssertionLogger.Log(exception);
            throw exception;
        }

        public void OrCall(Action action)
        {
            if (_predicate.Value) { return; }

            action();
        }

        #endregion Methods
    }
}

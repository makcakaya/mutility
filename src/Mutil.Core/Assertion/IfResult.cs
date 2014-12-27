using Mutil.Core.DataTypes;
using System;

namespace Mutil.Core.Assertion
{
    public sealed class IfResult
    {
        #region Fields

        private OneTime<bool> _predicate = new OneTime<bool>();

        #endregion Fields

        public IfResult(bool value)
        {
            _predicate.Value = value;
        }

        public void Throw<T>() where T : Exception
        {
            if (!_predicate.Value) { return; }
            throw (T)Activator.CreateInstance<T>();
        }


        public void Throw<T>(T exception) where T : Exception
        {
            if (!_predicate.Value) { return; }
            throw exception;
        }
    }
}

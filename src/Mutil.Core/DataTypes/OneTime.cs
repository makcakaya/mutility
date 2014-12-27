﻿
namespace Mutil.Core.DataTypes
{
    /// <summary>
    /// Objects of this class limits their values to be assigned only once.
    /// After assigning the value the first time, any further assignments will throw exceptions. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class OneTime<T>
    {
        #region Fields

        private T _value;
        private bool _locked = false;

        #endregion

        #region Properties

        /// <summary>
        /// Gets/Sets the value
        /// Throws ReadonlyException if assigned for more than once
        /// </summary>
        public T Value
        {
            get { return _value; }
            set
            {
                // TODO: Add assertion
                // Ensure.If(this.Locked).Throw<ReadonlyException>
                _value = value;
            }
        }

        public bool IsLocked
        {
            get { return _locked; }
        }

        #endregion

        #region Ctor

        public OneTime()
        {

        }

        public OneTime(T value)
        {
            this.Value = value;
        }

        #endregion
    }
}

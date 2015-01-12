using Mutil.Core.Exceptions;

namespace Mutil.Core.DataTypes
{
    /// <summary>
    /// Objects of this class limits their values to be assigned only once.
    /// After assigning the value the first time, any further assignments will throw exceptions. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class WriteOnce<T>
    {
        #region Field

        private T _value;
        private bool _isLocked = false;

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
                if (this.IsLocked) { throw new WriteOnceException(); }

                _value = value;
                _isLocked = true;
            }
        }

        public bool IsLocked
        {
            get { return _isLocked; }
        }

        #endregion

        #region Ctor

        public WriteOnce() { }

        public WriteOnce(T value)
        {
            this.Value = value;
        }

        #endregion
    }
}

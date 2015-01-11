using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mutil.Core.Assertion
{
    /// <summary>
    /// Provides facilities that eases the management of assertions and condition checking
    /// throwing exceptions etc.
    /// Example: ensure.If(mybool).Throw<ArgumentException>("customMessage")
    /// </summary>
    public static class Ensure
    {
        #region Fields

        private const string _ctorId = "*CONSTRUCTOR*";
        private const string _returnsId = "*RETURNS*";

        #endregion Fields

        #region Properties

        public static string CtorId
        {
            get { return _ctorId; }
        }

        public static string ReturnsId
        {
            get { return _returnsId; }
        }

        #endregion Properties

        #region Public Methods

        public static IfResult If(bool value)
        {
            // Return a new IfResult object that will provide fluent API for caller
            return new IfResult(value);
        }

        public static void NotNull<T>(T obj, string argumentName = null) where T : class
        {
            if(object.ReferenceEquals(obj, null))
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void NotEmpty(string obj, string argumentName = null)
        {
            if(string.IsNullOrEmpty(obj))
            {
                throw new ArgumentException(argumentName);
            }
        }

        public static void NotNullOrWhitespace(string obj, string argumentName = null)
        {
            if(string.IsNullOrWhiteSpace(obj))
            {
                throw new ArgumentException(argumentName);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private static string GetStackTrace(int trimStackFrame)
        {
            var trace = new StackTrace();
            var sb = new StringBuilder();
            for (int i = 1; i < trace.FrameCount; i++)
            {
                var frame = trace.GetFrame(i);
                var method = frame.GetMethod();
                sb.Append(string.Format("{0}: {1}.{2}",
                    (trace.FrameCount - i) - trimStackFrame, method.DeclaringType.FullName, method.Name));
                if (method.IsConstructor) { sb.Append(CtorId); }
                if (method is MethodInfo)
                {
                    sb.Append(string.Format(ReturnsId, ((MethodInfo)method).ReturnType.FullName));
                }
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        #endregion Private Methods
    }
}

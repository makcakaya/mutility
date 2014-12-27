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
    public sealed class Ensure
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

        public IfResult If(bool value)
        {
            // Return a new IfResult object that will provide fluent API for caller
            return new IfResult(value);
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Mutil.Core.Assertion
{
    /// <summary>
    /// Provides methods to handle assertions and throwing exceptions when assertions fail.
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

        public static ThatResult That(bool value)
        {
            return new ThatResult(value); // Fluent API
        }

        public static void NotNull<T>(T obj, string argumentName = null) where T : class
        {
            if (object.ReferenceEquals(obj, null))
            {
                var ex = new ArgumentNullException(argumentName);
                AssertionLogger.Log(ex);
                throw ex;
            }
        }

        public static void NotEmpty(string obj, string argumentName = null)
        {
            if (string.IsNullOrEmpty(obj))
            {
                var ex = new ArgumentException(argumentName);
                AssertionLogger.Log(ex);
                throw ex;
            }
        }

        public static void NotNullOrWhitespace(string obj, string argumentName = null)
        {
            if (string.IsNullOrWhiteSpace(obj))
            {
                var ex = new ArgumentException(argumentName);
                AssertionLogger.Log(ex);
                throw ex;
            }
        }

        public static void Contains<T>(IEnumerable<T> collection, T value) 
        {
            if (collection.Contains(value)) { return; }

            var ex = new InvalidOperationException(string.Format("{0} collection does not contain {1}", collection, value));
            AssertionLogger.Log(ex);
            throw ex;
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

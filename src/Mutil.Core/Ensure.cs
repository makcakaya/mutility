using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Mutil.Core
{
    public class Ensure
    {
        private const string CtorMessage = "is constructor";
        private const string ReturnsMessage = "returns";
        private readonly string _generalMessage;

        #region Ctor

        public Ensure()
        {

        }

        public Ensure(string generalMessage)
        {
            _generalMessage = generalMessage;
        }

        #endregion

        #region Methods

        public void That(Func<bool> predicate, Exception exception = null)
        {
            if (predicate()) { return; }
            else { throw exception ?? new Exception(_generalMessage + Environment.NewLine + GetStackTrace()); }
        }

        public void NotNull(object obj, Exception exception = null)
        {
            if (!object.ReferenceEquals(obj, null)) { return; }
            else { throw exception ?? new ArgumentNullException(_generalMessage + Environment.NewLine + GetStackTrace()); }
        }

        private string GetStackTrace()
        {
            var trace = new StackTrace();
            var sb = new StringBuilder();
            for (int i = 1; i < trace.FrameCount; i++)
            {
                var frame = trace.GetFrame(i);
                var method = frame.GetMethod();
                sb.Append(string.Format("{0}: {1}.{2}",
                    (trace.FrameCount - i) - 1, method.DeclaringType.FullName, method.Name));
                if (method.IsConstructor) { sb.Append(" ***IS CONSTRUCTOR*** "); }
                if (method is MethodInfo)
                {
                    sb.Append(string.Format(" ***RETURNS*** {0}", ((MethodInfo)method).ReturnType.FullName));
                }
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        #endregion
    }
}

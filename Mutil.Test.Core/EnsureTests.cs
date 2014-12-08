using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mutil.Core;

namespace Mutil.Test.Core
{
    [TestClass]
    public class EnsureTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Can_Throw_Expected_Exception()
        {
            var ensure = new Ensure("mutilensure");
            ensure.That(() => 1 == 2, new ArgumentOutOfRangeException());
        }

        [TestMethod]
        public void Can_Get_Stacktrace()
        {
            var ensure = new Ensure();
            try
            {
                ensure.That(() => 1 == 2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(e.Message.Contains("Mutil.Core.Ensure.That"));
            }
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mutil.Core;
using Mutil.Core.Assertion;

namespace Mutil.Test.Core
{
    [TestClass]
    public class EnsureTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Can_Throw_Expected_Exception()
        {
            Ensure.If(true).Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void Does_Not_Throw_If_Satisfied()
        {
            Ensure.If(false).Throw<ArgumentOutOfRangeException>();
        }

   }
}

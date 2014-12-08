using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mutil.Core.Exceptions;
using Mutil.Core.Ioc;
using System;
using System.IO;

namespace Mutil.Test.Core
{
    [TestClass]
    public class MiocTests
    {
        [TestMethod]
        public void Can_Register_And_Resolve_Basic()
        {
            var mioc = new Mioc();
            var stream = new MemoryStream(new byte[] { 0xff, 0x12 });
            mioc.Register<Stream>(stream);
            var resolved = mioc.Resolve<Stream>(null);
            Assert.AreEqual(stream, resolved);
        }

        [TestMethod]
        [ExpectedException(typeof(NotRegisteredException))]
        public void Can_Throw_When_Not_Registered_Type_Resolved()
        {
            var mioc = new Mioc();
            var resolved = mioc.Resolve<Stream>();
        }

        [TestMethod]
        public void Can_Register_And_Resolve_With_Arg()
        {
            var mioc = new Mioc();
            mioc.Register<Exception>((a) =>
            {
                var isInvalidEx = (bool)a;
                if (isInvalidEx) { return new InvalidOperationException(); }
                else { return new NotSupportedException(); }
            });

            var invalidEx = mioc.Resolve<Exception>(true);
            var notSupportedEx = mioc.Resolve<Exception>(false);
            Assert.AreEqual(typeof(InvalidOperationException), invalidEx.GetType());
            Assert.AreEqual(typeof(NotSupportedException), notSupportedEx.GetType());
        }
    }
}

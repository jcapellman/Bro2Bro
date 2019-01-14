using System;
using System.Linq;

using Bro2Bro.lib.Implementations;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bro2Bro.UnitTests.Implementations
{
    [TestClass]
    public class LiteDbTests
    {
        #region Cleanup

        [TestCleanup]
        public void Cleanup()
        {
            var db = new LiteDbDatabase();

            
        }

        #endregion
        #region RegisterBro
        [TestMethod]
        public void RegisterBroNull()
        {
            var db = new LiteDbDatabase();

            var result = db.RegisterBro(null, null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RegisterBroNew()
        {
            var db = new LiteDbDatabase();

            var result = db.RegisterBro(Guid.NewGuid().ToString(), "John Wick");

            Assert.IsTrue(result);
        }
        #endregion

        #region GetBros
        [TestMethod]
        public void GetBrosNull()
        {
            var db = new LiteDbDatabase();

            var result = db.GetBros(null);

            Assert.IsNotNull(result);
            Assert.IsTrue(!result.Any());
        }

        [TestMethod]
        public void GetBrosEmpty()
        {
            var db = new LiteDbDatabase();

            var result = db.GetBros(string.Empty);

            Assert.IsNotNull(result);
            Assert.IsTrue(!result.Any());
        }

        [TestMethod]
        public void GetBrosNotFound()
        {
            var db = new LiteDbDatabase();

            var result = db.GetBros("notfound");

            Assert.IsNotNull(result);
            Assert.IsTrue(!result.Any());
        }

        [TestMethod]
        public void GetBrosFound()
        {
            var db = new LiteDbDatabase();

            var result = db.GetBros("found");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.Count == 1);
        }
#endregion
    }
}
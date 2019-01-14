using System.Linq;

using Bro2Bro.lib.Implementations;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bro2Bro.UnitTests.Implementations
{
    [TestClass]
    public class LiteDbTests
    {
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
    }
}
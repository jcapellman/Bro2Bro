using System.Threading.Tasks;

using Bro2Bro.lib.HttpHandlers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bro2Bro.UnitTests.HttpHandlers
{
    [TestClass]
    public class FindBroHandlerTests
    {
        private const string SERVER_BASE_URL = "http://localhost:5000/api/";

        [TestMethod]
        public async Task NullTest()
        {
            var findBroHandler = new FindBroHandler(SERVER_BASE_URL);

            var result = await findBroHandler.FindBrosAsync(null);
        }
    }
}
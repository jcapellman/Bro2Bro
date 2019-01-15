using System.Threading.Tasks;

using Bro2Bro.lib.HttpHandlers;
using Bro2Bro.UnitTests.HttpHandlers.Base;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bro2Bro.UnitTests.HttpHandlers
{
    [TestClass]
    public class FindBroHandlerTests : BaseHttpTests
    {
        [TestMethod]
        public async Task NullTest()
        {
            var findBroHandler = new FindBroHandler(SERVER_BASE_URL);

            var result = await findBroHandler.FindBrosAsync(null);
        }
    }
}